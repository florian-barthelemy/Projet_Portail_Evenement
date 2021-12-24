//création carte
function createMap()
{
    if ($('#map').length) {


        var map = L.map('map').setView([50.636565, 3.063528], 13);
        

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1Ijoia2FsZXJhc2VyIiwiYSI6ImNreGdhODVtazJnc3Iyb28xNHhuYzJkdmoifQ.I0vusjH3phNxs5E9VwJI0w'
        }).addTo(map);
        return map;
    } //endif map
    else {
        alert('erreur js');
        return null;
    }
}

