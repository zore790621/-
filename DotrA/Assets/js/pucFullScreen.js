function hasClass(obj, cls) {
    return obj.className.match(new RegExp('(\\s|^)' + cls + '(\\s|$)'));
}

function addClass(obj, cls) {
    if (!this.hasClass(obj, cls)) obj.className += " " + cls;
}

function removeClass(obj, cls) {
    if (hasClass(obj, cls)) {
        var reg = new RegExp('(\\s|^)' + cls + '(\\s|$)');
        obj.className = obj.className.replace(reg, ' ');
    }
}


window.addEventListener('load', function () {
    var imgAll = document.getElementsByClassName('post-body')[0];
    if (imgAll == undefined) {
        return;
    }

    var imgs = imgAll.getElementsByTagName('img')
    for (var i = 0; i < imgs.length; i++) {
        //如果设置非全屏标志则跳过
        if (hasClass(imgs[i], 'class_no_full_screen')) {
            continue;
        }

        imgs[i].setAttribute('style', "cursor: zoom-in");
        imgs[i].onclick = function () {

            var section = document.getElementsByTagName("section")[0];

            var imgView = document.getElementById('imgViewDom');
            if (imgView == undefined) {
                imgView = document.createElement("div");
                imgView.id = "imgViewDom";

                section.appendChild(imgView)

                imgView.onclick = function () {
                    addClass(imgView, "disnone");
                    imgView.innerHTML = "";
                }
            }

            imgView.innerHTML = "<img id = 'jackslowfuck' src=" + this.src + " style='cursor: zoom-out; max-width: 100%;'" + ">";
            removeClass(imgView, "disnone");

            var jackslowfuck = document.getElementById('jackslowfuck');
            jackslowfuck.onclick = function () {
                addClass(imgView, "disnone");
                imgView.innerHTML = "";
            }

        }
    }

}, false);