/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


function changeLangue(param) {

    var val;
    val = param;

    var xhr = new XMLHttpRequest();
    var reponseJSON, resultat;
    xhr.onreadystatechange = function () {
        console.log(this);
        if (this.readyState == 4 && this.status == 200) {

            reponseJSON = this.responseText;
            resultat = JSON.parse(reponseJSON);

            if (resultat = 'ok') {
              window.location.reload(true);
            }
        }
    }
    xhr.open("GET", "/Home/langue?culture=" + val, true);
    xhr.send();



}