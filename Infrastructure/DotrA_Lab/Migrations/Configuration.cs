using DotrA_Lab.Business.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DotrA_Lab.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DotrA_Lab.ORM.Context.DotrADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotrA_Lab.ORM.Context.DotrADbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.MemberRole.AddOrUpdate(
                    new MemberRole() { RoleID = 1, RoleName = "admin" },
                    new MemberRole() { RoleID = 2, RoleName = "customer" },
                    new MemberRole() { RoleID = 3, RoleName = "member" },
                    new MemberRole() { RoleID = 4, RoleName = "guest" }
                );
            context.Member.AddOrUpdate(new Member()
            {
                MemberID = 1,
                MemberAccount = "admin",
                Password = "bg1ro4pMF0i3iA1oU4XaZnOzjXCziNRnUZyTs3k3lUs=",
                Name = "admin",
                Email = "DotrA@gmail.com",
                Address = "DotrA",
                Phone = "0900-000-000",
                RoleID = 1,
                HashCode = "UjL6sJixyF",
                EmailVerified = true,
                ActivationCode = new Guid("feed2e92-67ff-42a9-9664-acaecdb0f1df")
            });
            context.Product.AddOrUpdate(
                new Product() { ProductID = 1, ProductName = "原味黑糖磚", SupplierID = 1, CategoryID = 1, UnitPrice = 115, ProductDescription = "『添糖』看見您的辛苦  添個好糖吧。在您的健康、在您的心情、在您的生活。 請慢下來吧,幫您的身、心、靈、補充臺灣特有的黑糖風味與在地的新鮮。  嚴選臺灣優質食材，例如南投竹薑，臺東小油菊等。 從研發、製做與設計皆在臺灣完成。 在現代化與科技化設備製作中，貫徹老師傅古法精神，鎔鑄成味覺的美好記憶。  女性朋友，愛自己千萬不能勤儉！", Quantity = 200, SalesPrice = 150, Status = true },
                new Product() { ProductID = 2, ProductName = "食物乾燥塊", SupplierID = 1, CategoryID = 1, UnitPrice = 699, ProductDescription = "null", Quantity = 300, SalesPrice = 899, Status = true },
                new Product() { ProductID = 3, ProductName = "硅藻土杯墊", SupplierID = 1, CategoryID = 1, UnitPrice = 166, ProductDescription = "	可做吸水杯墊、肥皂墊或防潮塊擺設	", Quantity = 300, SalesPrice = 255, Status = true },
                new Product() { ProductID = 4, ProductName = "Lexnfant大象學習筷", SupplierID = 1, CategoryID = 1, UnitPrice = 104, ProductDescription = "‧輔助訓練幼童學習筷子技能 ‧大象套可替換各種規模的筷子 ‧適合高溫水煮殺菌 ‧六種顏色可供選擇 耐高溫且材質穩定耐用，通過SGS認證合格，無臭無毒健康保證。 不含塑化劑、雙酚A等有毒物質，給自己一個環保與健康的聰明新選擇！", Quantity = 300, SalesPrice = 149, Status = true },
                new Product() { ProductID = 5, ProductName = "PROM 恐龍枕", SupplierID = 1, CategoryID = 1, UnitPrice = 524, ProductDescription = "家長們還在擔心出遊時孩子吵個不停嗎？ 韓國熱銷「PROM恐龍枕」會是你最棒救星！ 可愛的造型送禮、自用兩相宜！", Quantity = 500, SalesPrice = 699, Status = true },
                new Product() { ProductID = 6, ProductName = "iGimmick矽膠拆疊餐盒", SupplierID = 1, CategoryID = 1, UnitPrice = 419, ProductDescription = "摺疊設計 一秒變成大容量 貼心設計醬料盒 也可做隨身杯子 上蓋輕鬆收納餐具 (附餐具組) 100％矽膠食品級材料 環保無毒 不變質 可折疊式功能，輕鬆節省存儲空間", Quantity = 100, SalesPrice = 599, Status = true },
                new Product() { ProductID = 7, ProductName = "環保可拆卸吸管", SupplierID = 1, CategoryID = 1, UnitPrice = 202, ProductDescription = "環保減塑的政策上路 沒有吸管是不是有點困擾呢？ 環保可拆卸吸管解決您的困擾！ Lexngo採用矽膠的材質 並且採用特殊開縫設計 讓清洗不再是個困擾 讓您在兼顧環保的同時也可以用的方便！", Quantity = 600, SalesPrice = 269, Status = true },
                new Product() { ProductID = 8, ProductName = "小怪獸USB熱敷眼罩", SupplierID = 1, CategoryID = 1, UnitPrice = 359, ProductDescription = "平常上班勞碌，回家又離不開3C產品的朋友們 讓小怪獸用可愛還有實際的功效，慰撫慰您忙碌的心靈還有眼睛❤️❤️", Quantity = 250, SalesPrice = 479, Status = true },
                new Product() { ProductID = 9, ProductName = "小怪獸帶帽記憶頸枕", SupplierID = 1, CategoryID = 1, UnitPrice = 337, ProductDescription = "出遊、上班想要好好休息只有頸枕還不夠！？ 小怪獸聽見您的心聲！推出這款「小怪獸帶帽記憶頸枕」 不僅外型可愛，更有小怪獸系列一貫的貼心設計 帶帽的設計不僅讓團友們睡覺不用怕被看見睡臉 更可以遮光、遮風，讓我們可以安心、舒服的睡個好覺！", Quantity = 150, SalesPrice = 449, Status = true },
                new Product() { ProductID = 10, ProductName = "SAVO洋芋片", SupplierID = 1, CategoryID = 1, UnitPrice = 104, ProductDescription = "源自盎格魯撒克遜人的飲食方式，入口甜美的波特酒香，帶出香濃的乾酪奶味，味蕾的感動，如天 秤般諧和完美。", Quantity = 500, SalesPrice = 139, Status = true },
                new Product() { ProductID = 11, ProductName = "抹茶杏仁捲心酥", SupplierID = 1, CategoryID = 1, UnitPrice = 110, ProductDescription = "1.採用抹茶抹茶粉製作,並增量製作,使抹茶風味更加濃厚些 2.採用較高檔的比利時巧克力以及美國杏仁果製作,與市面上商品,在抹茶味及口感上更加有 層次 3.一款適合抹茶愛好者於下午茶時光食用,更是辦公室療癒小點的好選擇", Quantity = 600, SalesPrice = 180, Status = true },
                new Product() { ProductID = 12, ProductName = "Gopro自拍浮力棒", SupplierID = 1, CategoryID = 1, UnitPrice = 107, ProductDescription = "	● 真空填充設計，漂浮落水也不怕 ● 輕鬆握持，自由拍攝不求人 ● 顏色鮮明，在水中容易被發現 ● 安全手腕帶，雙重防護不怕用丟 ● 1/4吋螺旋雲台，適用多種相機 ● 適用於衝浪、浮潛、划船等各式運動", Quantity = 23, SalesPrice = 179, Status = true },
                new Product() { ProductID = 13, ProductName = "360自拍棒藍牙遙控器", SupplierID = 1, CategoryID = 1, UnitPrice = 215, ProductDescription = "手機拍照越來越方便，甚至已經成為一門大學問！ 「Smile-360 自拍棒藍牙遙控器」讓您用手機拍照更方便 拍法更多元、捕捉各種角度！", Quantity = 150, SalesPrice = 269, Status = true },
                new Product() { ProductID = 14, ProductName = "AF215 手持隨身風扇", SupplierID = 1, CategoryID = 1, UnitPrice = 360, ProductDescription = "出門在外總是滿頭大汗！？在辦公室忙得暈頭轉向讓您火冒三丈！？ 「ZMI紫米隨身風扇」為您一次解決這些問題！ 3350mAh電力，持久續航力讓炎夏外出隨身攜帶一隻在身上 減少炎熱感覺，三段風力調節、安靜低噪音。", Quantity = 350, SalesPrice = 450, Status = true },
                new Product() { ProductID = 15, ProductName = "Tsum珪藻土地墊", SupplierID = 1, CategoryID = 1, UnitPrice = 525, ProductDescription = "採全天然硅藻土製成 ✅綠能環保 ✅超強吸水 ✅吸附異味 ✅淨化空氣 ✅釋放負氧離子 ✅防霉抗菌", Quantity = 800, SalesPrice = 700, Status = true }
                );
            context.ImageBase.AddOrUpdate(
                new ImageBase() { ImageID = 1, CatgoryID = null, ProductID = 1, ImageName = "6Ca6lf9", ImageUrl = "~/Assets/Images/Product/1_5ed1c796-cb77-4e8c-82bc-4f2832dd5426_6Ca6lf9.jpg" },
                new ImageBase() { ImageID = 2, CatgoryID = null, ProductID = 2, ImageName = "5lCD25s", ImageUrl = "~/Assets/Images/Product/2_c1a0e4e5-73a4-48da-b779-9cdad78c6648_5lCD25s.jpg" },
                new ImageBase() { ImageID = 3, CatgoryID = null, ProductID = 4, ImageName = "QMY4swg", ImageUrl = "~/Assets/Images/Product/4_1baef446-b20b-4ac5-82ce-469ee0349bdc_QMY4swg.jpg" },
                new ImageBase() { ImageID = 4, CatgoryID = null, ProductID = 11, ImageName = "aoMdX6G", ImageUrl = "~/Assets/Images/Product/11_0662a20d-4902-4032-a64f-3aa2854a0c11_aoMdX6G.jpg" },
                new ImageBase() { ImageID = 5, CatgoryID = null, ProductID = 3, ImageName = "Xe2t44A", ImageUrl = "~/Assets/Images/Product/3_3afb9d12-ce20-4aa2-ac9b-983d31fd3af0_Xe2t44A.jpg" },
                new ImageBase() { ImageID = 6, CatgoryID = null, ProductID = 3, ImageName = "Xe2t44A", ImageUrl = "~/Assets/Images/Product/3_af6b1a25-6689-45ad-a22f-c07bc874e890_Xe2t44A.jpg" },
                new ImageBase() { ImageID = 7, CatgoryID = null, ProductID = 5, ImageName = "tf5jDAd", ImageUrl = "~/Assets/Images/Product/5_9f60a077-ed65-4dc8-8f40-cdaab8812e92_tf5jDAd.jpg" },
                new ImageBase() { ImageID = 8, CatgoryID = null, ProductID = 5, ImageName = "tf5jDAd", ImageUrl = "~/Assets/Images/Product/5_8bb98757-6d1f-45e2-8dc1-03d4f17156fb_tf5jDAd.jpg" },
                new ImageBase() { ImageID = 9, CatgoryID = null, ProductID = 5, ImageName = "mG1511f", ImageUrl = "~/Assets/Images/Product/5_f0e9b906-723a-4e77-b844-0dfc95b14580_mG1511f.jpg" },
                new ImageBase() { ImageID = 10, CatgoryID = null, ProductID = 5, ImageName = "oFxK751", ImageUrl = "~/Assets/Images/Product/5_ddd929b1-46a1-450f-9210-6a9b6d7154a8_oFxK751.jpg" },
                new ImageBase() { ImageID = 11, CatgoryID = null, ProductID = 6, ImageName = "mxB76es", ImageUrl = "~/Assets/Images/Product/6_cf8d2e6c-1146-4754-a978-3a222fa9f9e3_mxB76es.jpg" },
                new ImageBase() { ImageID = 12, CatgoryID = null, ProductID = 6, ImageName = "wLzCY8D", ImageUrl = "~/Assets/Images/Product/6_c7765ad1-f581-49af-94ef-7bd8de490a6e_wLzCY8D.jpg" },
                new ImageBase() { ImageID = 13, CatgoryID = null, ProductID = 6, ImageName = "Q5heLLl", ImageUrl = "~/Assets/Images/Product/6_cdca51be-753b-449d-a677-472f0012ac23_Q5heLLl.jpg" },
                new ImageBase() { ImageID = 14, CatgoryID = null, ProductID = 6, ImageName = "mxB76es", ImageUrl = "~/Assets/Images/Product/6_c935cec4-0102-4f6d-9cee-f77b701a4c62_mxB76es.jpg" },
                new ImageBase() { ImageID = 15, CatgoryID = null, ProductID = 7, ImageName = "iFHPYAt", ImageUrl = "~/Assets/Images/Product/7_5efa9f7c-78fa-4d8c-b4a1-36f4c2768e26_iFHPYAt.jpg" },
                new ImageBase() { ImageID = 16, CatgoryID = null, ProductID = 7, ImageName = "iFHPYAt", ImageUrl = "~/Assets/Images/Product/7_17f89804-533c-41f7-94da-bd69686d8e46_iFHPYAt.jpg" },
                new ImageBase() { ImageID = 17, CatgoryID = null, ProductID = 7, ImageName = "PIIG9iN", ImageUrl = "~/Assets/Images/Product/7_7e577553-81bf-4138-ac81-71f3a6410de5_PIIG9iN.jpg" },
                new ImageBase() { ImageID = 18, CatgoryID = null, ProductID = 8, ImageName = "pUPkWWZ", ImageUrl = "~/Assets/Images/Product/8_e5dc4917-9c6c-4297-91ff-0927907173dc_pUPkWWZ.jpg" },
                new ImageBase() { ImageID = 19, CatgoryID = null, ProductID = 8, ImageName = "WmWUgKc", ImageUrl = "~/Assets/Images/Product/8_4ed27ff3-e6cf-4c3b-967b-9f7ce46a4d27_WmWUgKc.jpg" },
                new ImageBase() { ImageID = 20, CatgoryID = null, ProductID = 8, ImageName = "pUPkWWZ", ImageUrl = "~/Assets/Images/Product/8_ffd38994-9cb8-4a4a-b5f0-d436ce0ddaf9_pUPkWWZ.jpg" },
                new ImageBase() { ImageID = 21, CatgoryID = null, ProductID = 9, ImageName = "YSMwTef", ImageUrl = "~/Assets/Images/Product/9_249f2409-70cf-40ce-9ce8-559c066ffd1e_YSMwTef.jpg" },
                new ImageBase() { ImageID = 22, CatgoryID = null, ProductID = 9, ImageName = "U72cdnP", ImageUrl = "~/Assets/Images/Product/9_4cca4946-3bda-47f0-a695-f2f4ea900a94_U72cdnP.jpg" },
                new ImageBase() { ImageID = 23, CatgoryID = null, ProductID = 9, ImageName = "qJJu5Uq", ImageUrl = "~/Assets/Images/Product/9_f612e916-207b-4ce3-9067-68677f53ee74_qJJu5Uq.jpg" },
                new ImageBase() { ImageID = 24, CatgoryID = null, ProductID = 9, ImageName = "wsHvm01", ImageUrl = "~/Assets/Images/Product/9_41bc875c-c853-4045-89b6-7e43ee65733a_wsHvm01.jpg" },
                new ImageBase() { ImageID = 25, CatgoryID = null, ProductID = 9, ImageName = "YSMwTef", ImageUrl = "~/Assets/Images/Product/9_9db5a5aa-bf49-4fbe-9e6b-28f2625659c8_YSMwTef.jpg" },
                new ImageBase() { ImageID = 26, CatgoryID = null, ProductID = 10, ImageName = "6kLyNur", ImageUrl = "~/Assets/Images/Product/10_fa087640-3331-4bc4-9013-b65a9d6a9503_6kLyNur.jpg" },
                new ImageBase() { ImageID = 27, CatgoryID = null, ProductID = 10, ImageName = "6kLyNur", ImageUrl = "~/Assets/Images/Product/10_a871b7ee-d537-483e-b327-3702a65b9776_6kLyNur.jpg" },
                new ImageBase() { ImageID = 28, CatgoryID = null, ProductID = 12, ImageName = "zp2WUZD", ImageUrl = "~/Assets/Images/Product/12_aa13840d-d78b-4a8e-98c1-d9b5a0f75689_zp2WUZD.jpg" },
                new ImageBase() { ImageID = 29, CatgoryID = null, ProductID = 12, ImageName = "KzAOls4", ImageUrl = "~/Assets/Images/Product/12_02b6b3f5-9dd5-480f-a077-6970fee34980_KzAOls4.jpg" },
                new ImageBase() { ImageID = 30, CatgoryID = null, ProductID = 12, ImageName = "JMfpkrz", ImageUrl = "~/Assets/Images/Product/12_b0c10223-38b7-4e71-983b-2b658174cf21_JMfpkrz.jpg" },
                new ImageBase() { ImageID = 31, CatgoryID = null, ProductID = 12, ImageName = "zp2WUZD", ImageUrl = "~/Assets/Images/Product/12_07e8dcaf-72f3-4e0d-b690-9d3ba97d58bd_zp2WUZD.jpg" },
                new ImageBase() { ImageID = 32, CatgoryID = null, ProductID = 13, ImageName = "hW3nYcL", ImageUrl = "~/Assets/Images/Product/13_07e89027-1cf2-48ee-95ce-e5394bbe724e_hW3nYcL.jpg" },
                new ImageBase() { ImageID = 33, CatgoryID = null, ProductID = 13, ImageName = "hW3nYcL", ImageUrl = "~/Assets/Images/Product/13_0590906b-1f0c-41be-8a82-00047eeaead9_hW3nYcL.jpg" },
                new ImageBase() { ImageID = 34, CatgoryID = null, ProductID = 13, ImageName = "wrIuOxJ", ImageUrl = "~/Assets/Images/Product/13_19b379d6-070d-425b-9a92-bb2fe30605e7_wrIuOxJ.jpg" },
                new ImageBase() { ImageID = 35, CatgoryID = null, ProductID = 13, ImageName = "67DSw33", ImageUrl = "~/Assets/Images/Product/13_67e09282-1d65-4b50-a50a-b0c6190ef22d_67DSw33.jpg" },
                new ImageBase() { ImageID = 36, CatgoryID = null, ProductID = 13, ImageName = "77WCIwm", ImageUrl = "~/Assets/Images/Product/13_e0d1dcbc-6dc4-4e93-aecd-0871b7325a62_77WCIwm.jpg" },
                new ImageBase() { ImageID = 37, CatgoryID = null, ProductID = 14, ImageName = "GlbnYNW", ImageUrl = "~/Assets/Images/Product/14_354a23c9-b880-4035-8175-49bb8d5a9993_GlbnYNW.jpg" },
                new ImageBase() { ImageID = 38, CatgoryID = null, ProductID = 14, ImageName = "GlbnYNW", ImageUrl = "~/Assets/Images/Product/14_9596a852-329f-4e04-bfb9-3a7f5b8b2038_GlbnYNW.jpg" },
                new ImageBase() { ImageID = 39, CatgoryID = null, ProductID = 14, ImageName = "uAQJFX3", ImageUrl = "~/Assets/Images/Product/14_8dd5334c-3632-4fe2-92f6-c91ef201bc83_uAQJFX3.jpg" },
                new ImageBase() { ImageID = 40, CatgoryID = null, ProductID = 14, ImageName = "3FGtIv1", ImageUrl = "~/Assets/Images/Product/14_fdccaf78-da11-4726-907d-f584dc407edc_3FGtIv1.jpg" },
                new ImageBase() { ImageID = 41, CatgoryID = null, ProductID = 14, ImageName = "fOfPlUM", ImageUrl = "~/Assets/Images/Product/14_52244fbd-b57d-455c-be44-a7aae68bd0e3_fOfPlUM.jpg" },
                new ImageBase() { ImageID = 42, CatgoryID = null, ProductID = 14, ImageName = "lex0a85", ImageUrl = "~/Assets/Images/Product/14_d178d709-350f-4694-89db-38009c7ec7f6_lex0a85.jpg" },
                new ImageBase() { ImageID = 43, CatgoryID = null, ProductID = 14, ImageName = "jjy6ff4", ImageUrl = "~/Assets/Images/Product/14_10160319-b6bc-43b6-8046-3ba9cdb13abe_jjy6ff4.jpg" },
                new ImageBase() { ImageID = 44, CatgoryID = null, ProductID = 14, ImageName = "7yP1SJe", ImageUrl = "~/Assets/Images/Product/14_3776e1b4-7ae9-4987-a8b0-a34bd04e32d3_7yP1SJe.jpg" },
                new ImageBase() { ImageID = 45, CatgoryID = null, ProductID = 14, ImageName = "1bO4awh", ImageUrl = "~/Assets/Images/Product/14_8e30246a-6228-4ec0-a96b-31fcaf9c452d_1bO4awh.jpg" },
                new ImageBase() { ImageID = 46, CatgoryID = null, ProductID = 15, ImageName = "jYBxvpE", ImageUrl = "~/Assets/Images/Product/15_447d4b09-ea5d-4955-91b4-d68771722a6e_jYBxvpE.jpg" },
                new ImageBase() { ImageID = 47, CatgoryID = null, ProductID = 15, ImageName = "jYBxvpE", ImageUrl = "~/Assets/Images/Product/15_9cfbbac1-6d09-41fd-b7e7-ed5843f33862_jYBxvpE.jpg" },
                new ImageBase() { ImageID = 48, CatgoryID = null, ProductID = 15, ImageName = "I9VWRYJ", ImageUrl = "~/Assets/Images/Product/15_abf51515-1344-4881-afa4-283739358f3b_I9VWRYJ.jpg" },
                new ImageBase() { ImageID = 49, CatgoryID = null, ProductID = 15, ImageName = "SAk9FuI", ImageUrl = "~/Assets/Images/Product/15_c1b50f3d-7eae-4902-b7c6-cb3a05260e93_SAk9FuI.jpg" }
                );

        }
    }
}
