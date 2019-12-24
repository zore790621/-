using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IMemberService : IService<Member>
    {
        /// <summary>
        /// 新增Member
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel型別</typeparam>
        /// <param name="viewModel">ViewModel物件</param>
        /// <param name="password">ViewModel填入之Password</param>
        /// <returns></returns>
        string AddMember<TViewModel>(TViewModel viewModel, string password);
        bool CheckEmailVerify(string Account);
        void MemberMoidfyPassword<TViewModel>(TViewModel source, int id, string repassword);
        Member UserLogin(string account, string password);
        /// <summary>
        /// 會員信箱認證
        /// </summary>
        /// <param name="account">會員</param>
        void VerifyAccount(Member account);
    }
    public class MemberService
        : GenericService<Member>, IMemberService
    {
        public MemberService(IUnitOfWork db)
            : base(db) { }

        public string AddMember<TViewModel>(TViewModel viewModel, string password)
        {
            var keyNew = Hash.GeneratePassword(10);
            Member entity = new Member()
            {
                ActivationCode = Guid.NewGuid(),
                HashCode = keyNew,//hash 加密
                EmailVerified = false,//註冊時將Email認證設為false
                RoleID = 4 //初始為Guest
            };
            DataModelToViewModel.GenericMapper(viewModel, entity);

            var hashPasswrod = Hash.EncodePassword(password, keyNew);

            entity.Password = hashPasswrod;

            db.Repository<Member>().Create(entity);
            db.SaveChanges();

            return entity.ActivationCode.ToString();
        }
        public Member UserLogin(string account, string password)
        {
            var user = db.Repository<Member>().Read(x => x.MemberAccount == account);

            var HCode = user.HashCode;

            var encodingPasswordString = Hash.EncodePassword(password, HCode);

            var result = db.Repository<Member>().Read(x => x.MemberAccount == account && x.Password.Equals(encodingPasswordString));

            return result;
        }
        public void VerifyAccount(Member Account)
        {
            var entity = db.Repository<Member>().Read(x => x.MemberID == Account.MemberID);
            entity.EmailVerified = true;
            entity.RoleID = 3;

            db.Repository<Member>().Update(entity);

            db.SaveChanges();
        }
        public override void Delete(Expression<Func<Member, bool>> wherePredicate)
        {
            var data = db.Repository<Member>().Read(wherePredicate);
            var target1 = db.Repository<Order>().Reads().Where(x => x.MemberID == data.MemberID);
            foreach (var a in target1)
            {
                var target2 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == a.OrderID);
                foreach (var b in target2)
                    db.Repository<OrderDetail>().Delete(b);
                db.Repository<Order>().Delete(a);
            }
            db.Repository<Member>().Delete(data);
            db.SaveChanges();
        }
        public bool CheckEmailVerify(string Account) => db.Repository<Member>().Read(x => x.MemberAccount == Account).EmailVerified;

        public void MemberMoidfyPassword<TViewModel>(TViewModel viewModel, int id, string repassword)
        {
            var entity = db.Repository<Member>().Read(x => x.MemberID == id);
            DataModelToViewModel.GenericMapper(viewModel, entity);
            var hashPasswrod = Hash.EncodePassword(repassword, entity.HashCode);
            entity.ResetPasswordCode = entity.Password;
            entity.Password = hashPasswrod;
            db.Repository<Member>().Update(entity);
        }
    }
}
