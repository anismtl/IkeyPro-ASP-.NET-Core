/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

function inscription() {
    var mail;
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    mail = document.getElementById("email").value;

    if (mail.match(mailformat)) {
        document.getElementById("resultat").innerHTML = " ";
        var xhr = new XMLHttpRequest();
        var reponseJSON, liste;
        xhr.onreadystatechange = function () {
            console.log(this);
            if (this.readyState == 4 && this.status == 200) {
                reponseJSON = this.responseText;
                liste = JSON.parse(reponseJSON);
                s = '<br/><a color="red"><b>' + liste + '</b></a> ';
                document.getElementById("resultat").innerHTML = s;
            }
        }
        xhr.open("GET", "Ajax?action=Inscription&courriel=" + mail, true);
        xhr.send();
    } else if (mail == "") {
        document.getElementById("resultat").innerHTML = "<br/><a><b>Veuilliz saisir votre courriel</b></a>";
        document.news.email.focus();
    } else {
        document.getElementById("resultat").innerHTML = "<br/><a><b>Format Courriel Incorrect</b></a> ";
        document.news.email.value = " ";
        document.news.email.focus();
    }
}

function desabonner() {
    var mail;
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    mail = document.getElementById("email").value;

    if (mail.match(mailformat)) {
        document.getElementById("resultat").innerHTML = " ";
        var xhr = new XMLHttpRequest();
        var reponseJSON, liste;
        xhr.onreadystatechange = function () {
            console.log(this);
            if (this.readyState == 4 && this.status == 200) {
                reponseJSON = this.responseText;
                liste = JSON.parse(reponseJSON);
                s = '<br/><a color="red"><b>' + liste + '</b></a> ';
                document.getElementById("resultat").innerHTML = s;
            }
        }
        xhr.open("GET", "Ajax?action=Surpression&courriel=" + mail, true);
        xhr.send();
    } else if (mail == "") {
        document.getElementById("resultat").innerHTML = "<br/><a><b>Veuilliz saisir votre courriel</b></a>";
        document.news.email.focus();
    } else {
        document.getElementById("resultat").innerHTML = "<br/><a><b>Format Courriel Incorrect</b></a> ";
        document.news.email.value = " ";
        document.news.email.focus();
    }
}