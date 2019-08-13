
window.onload = f;
//document.getElementById("bChercher").addEventListener("click", chercher);
document.getElementById("Rechcat").addEventListener("change", Editeur_List);
document.getElementById("des").addEventListener("change", duree_List);

function f() {





    Cat_List();
    //   duree_List();
    //   Editeur_List();

}


function Cat_List() {

    var xhr = new XMLHttpRequest();
    var reponseJSON, liste, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {

            reponseJSON = this.responseText;
            liste = JSON.parse(reponseJSON);
            s = "<option>--Choisir--</option>";
            for (i = 0; i < liste.length; i++) {
                s += "<option value=" + liste[i].idCategorie + ">" + liste[i].categorie_Designation + "</option>";
            }
            document.getElementById("Rechcat").innerHTML = s;

        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "/Home/Cat", true);
    xhr.send();
}



function Editeur_List() {
    var val = document.getElementById("Rechcat").value;
    var xhr = new XMLHttpRequest();
    var reponseJSON, liste1, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {
            //console.log(this);
            reponseJSON = this.responseText;
            liste1 = JSON.parse(reponseJSON);
            b = "";
            s = "<option>--Choisir--</option> ";
            for (i = 0; i < liste1.length; i++) {
                s += "<option value=" + liste1[i].id_Editeur + ">" + liste1[i].editeur_Designation + "</option>";

            }

            document.getElementById("des").innerHTML = s;



        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "/Shop/RechEditeur?cat=" + val, true);
    xhr.send();
}


function duree_List() {
    var val1 = document.getElementById("Rechcat").value;
    var val2 = document.getElementById("des").value;
    var xhr = new XMLHttpRequest();
    var reponseJSON, liste2, s;
    xhr.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {

            reponseJSON = this.responseText;
            liste2 = JSON.parse(reponseJSON);
            s = "<option>--Choisir--</option>";
            for (i = 0; i < liste2.length; i++) {
                s += "<option value=" + liste2[i].id_Edition + ">" + liste2[i].edition_Designation + "</option>";
            }
            document.getElementById("dur").innerHTML = s;



        } else if (this.readyState == 4) {
            alert("Erreur AJAX");
        }
    }
    xhr.open("GET", "/Shop/RechEdition?cat=" + val1 + "&editeur=" + val2, true);
    xhr.send();
}





function chercher() {

    var val1, val2, val3;

    val1 = document.getElementById("Rechcat").value;
    val2 = document.getElementById("des").value;
    val3 = document.getElementById("dur").value;
    if (val1 == "--Choisir--") {
        alert(val1 + "Champ Region est Obligatoire");
    } else if (val2 == "--Choisir--") {
        alert("Champ Destination est Obligatoire");
    } else if (val3 == "--Choisir--") {
        alert("Champ Durée est Obligatoire");
    } //else {

//var xhr = new XMLHttpRequest();
//    var reponseJSON, liste2, s;
//    xhr.onreadystatechange = function () {
//
//        if (this.readyState == 4 && this.status == 200) {
//
////            reponseJSON = this.responseText;
////            liste2 = JSON.parse(reponseJSON);
////            s = "<option>--Choisir--</option>";
////            for (i = 0; i < liste2.length; i++) {
////                s += "<option value=" + liste2[i].id_Edition + ">" + liste2[i].Edition + "</option>";
////            }
////            document.getElementById("dur").innerHTML = s;
//
//
//
//        } else if (this.readyState == 4) {
//            alert("Erreur AJAX");
//        }
//    }
//    xhr.open("GET", "Ajax?action=Recherche&cat=" + val1 + "&editeur=" + val2+"&edition="+val3, true);
//    xhr.send();
//
//





     //   var chemin = "navires.php?reg=" + val1 + "&des=" + val2 + "&dur=" + val3;
      //  window.location.href = chemin;
  //  }
}



