window.onload = Loading;

function Loading() {
    getMostViewProduitList();
    getCategoriesList();
    alerty();
}
function alerty() {

    var isFired = localStorage.getItem('checkFired');

    if (isFired != '1') {
        swal({
            title: 'DISCLAIMER!',
            text: 'Please note that this site is not an actual store - it is for demo purposes only.',
            timer: 7000

        });
        localStorage.setItem('checkFired', '1');
    }
}

function getMostViewProduitList() {

    var xhr = new XMLHttpRequest();
    var reponseJSON, liste, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {

            reponseJSON = this.responseText;
            liste = JSON.parse(reponseJSON);

            s = '<div class="owl-carousel owl-theme viewed_slider" >';

            for (i = 0; i < liste.length; i++) {

                var v = $('<div class="col-md-2 owl-item"><div class="viewed_item d-flex flex-column align-items-center justify-content-center text-center"><div class="viewed_image"><img src="images/' + liste[i].image + '" alt=""></div><div class="viewed_content text-center"><div class="viewed_price">$' + liste[i].prix + '</div><div class="viewed_name"><a href="home/produit?codeProduit=' + liste[i].codeProduit + '">' + liste[i].designtion_produit + '</a></div></div><ul class="item_marks"><li class="item_mark item_discount">-25%</li><li class="item_mark item_new">new</li></ul></div></div>');
                v.appendTo('#des');
            }

        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "Home/MostViewed", true);
    xhr.send();
}


function getCategoriesList() {

    var xhr = new XMLHttpRequest();
    var reponseJSON, liste, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {

            reponseJSON = this.responseText;
            liste = JSON.parse(reponseJSON);

            for (i = 0; i < liste.length; i++) {
                s = $('<li><a href="Home/shop?categorie=' + liste[i].idCategorie + '"> ' + liste[i].categorie_Designation + ' <i class="fas fa-chevron-right"></i></a></li>');
                //s = $('<li><a href=" @Url.Action("Cat",new { ideCategorie = ' + liste[i].idCategorie + ' })" class="readMoreLink" > ' + liste[i].categorie_Designation + ' <i class="fas fa-chevron-right"></i></a></li>');
                
                s.appendTo('#cat');
            }



        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "Home/Cat", true);
    xhr.send();
}


function port_List() {
    var val = document.getElementById("Des").value;
    var xhr = new XMLHttpRequest();
    var reponseJSON, liste1, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {
            console.log(this);
            reponseJSON = this.responseText;
            liste1 = JSON.parse(reponseJSON);
            s = "<option>---Select---</option> ";
            for (i = 0; i < liste1.length; i++) {
                s += "<option value=" + liste1[i].port_depart + ">" + liste1[i].port_depart + "</option>";
            }

            document.getElementById("Port").innerHTML = s;
        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "getPort.php?dest=" + val, true);
    xhr.send();
}

