//manipualation carte Event Create/Edit
$(document).ready(function () {
    var map = createMap();
    if ($("#map").length) {
        $("#map").css("min-height", "250px");
        map.setView([46.90296, 1.90925], 5);
        var markers = L.markerClusterGroup();
        $(".event-map-pt").each(function (index) {
            let longi = $(this).attr("data-longix"); //x
            let lati = $(this).attr("data-latiy"); //y
            let id = $(this).attr("data-id"); //id
            let libelle = "<a class=\"mapPopupLink\" href=\"/Events/Details/"+id+"\">"+$(this).attr("data-libelle")+"</a>";
            let marker = L.marker([lati, longi], { title: libelle }); //ajout marker
            marker.bindPopup(libelle);
            markers.addLayer(marker);
        });
        map.addLayer(markers);
    } //endif map

}); //end ready