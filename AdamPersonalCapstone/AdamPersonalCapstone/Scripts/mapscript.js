var Map;

function createMap() {
    var options = {
        center: { lat: 43.0389, lng: 87.9065 },
        zoom: 10
    };

    map = new google.maps.Map(document.getElementById('map'), options);
}