
$(document).ready(function () {
    if ($('#map').length) {

    
    var map = L.map('map').setView([50.636565, 3.063528], 13);
    $("#map").css('min-height', '500px');

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'pk.eyJ1Ijoia2FsZXJhc2VyIiwiYSI6ImNreGdhODVtazJnc3Iyb28xNHhuYzJkdmoifQ.I0vusjH3phNxs5E9VwJI0w'
    }).addTo(map);

    $('#EventAdresse_Voie').keyup(function (e) {
        e.preventDefault();
        let adrLength = $(this).val().length;
        if (adrLength > 1) {
            let dataVal = $(this).val();
            let url = "https://api-adresse.data.gouv.fr/search/?q=" + dataVal;



            $.get(url,
                function (data) {
                    let tags = new Array();
                    if (data.features.length < 5) {
                        console.log(data.features);
                        $('#listAdresses').empty();
                        for (var i = 0; i < data.features.length; i++) {
                            tags[i] = data.features[i].properties.label;
                            $('#listAdresses').append("<option>" + tags[i]+"</option>");
                        }
                        if (data.features.length == 1) {
                            map.eachLayer((layer) => {
                                if (layer['_latlng'] != undefined)
                                    layer.remove();
                            });
                            //récupération long lat 
                            let lati = data.features[0].geometry.coordinates[1]; //y
                            let longi = data.features[0].geometry.coordinates[0]; //x
                            let ville = data.features[0].properties.city;
                            let cp = data.features[0].properties.postcode;
                            map.setView([lati, longi], 18);
                            L.marker([lati, longi]).addTo(map); //ajout marker

                            //insertion valeur Axe_X et Axe_y
                            $('#EventAdresse_Axe_X').val(longi);
                            $('#EventAdresse_Axe_Y').val(lati);

                            //insertion Ville
                            $('#EventAdresse_Ville').val(ville);
                            //insertion code postal
                            $('#EventAdresse_CodePostal').val(cp);
                        }
                        
                    }
                });
        }

    });
    } //endif map
    });
