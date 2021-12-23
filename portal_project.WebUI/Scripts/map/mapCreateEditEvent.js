//manipualation carte Event Create/Edit
$(document).ready(function () {
    var map = createMap();
    if ($("#map").length) {
        $('#searchAdresse').keyup(function (e) {
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
                                $('#listAdresses').append("<option>" + tags[i] + "</option>");
                            }
                            if (data.features.length == 1) {
                                map.eachLayer((layer) => {
                                    if (layer['_latlng'] != undefined)
                                        layer.remove();
                                });
                                //récupération long lat 
                                let lati = data.features[0].geometry.coordinates[1]; //y
                                let longi = data.features[0].geometry.coordinates[0]; //x
                                let road = data.features[0].properties.name;
                                let ville = data.features[0].properties.city;
                                let cp = data.features[0].properties.postcode;
                                map.setView([lati, longi], 18);
                                L.marker([lati, longi]).addTo(map); //ajout marker
                                //longi = longi.replace(".", ",");
                                //lati = lati.replace(".", ",");
                                //insertion valeur Axe_X et Axe_y

                                $('#EventAdresse_Axe_X').val(parseFloat(longi));
                                $('#EventAdresse_Axe_Y').val(parseFloat(lati));

                                //isertion rue/voie
                                $('#EventAdresse_Voie').val(road);
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

}); //end ready