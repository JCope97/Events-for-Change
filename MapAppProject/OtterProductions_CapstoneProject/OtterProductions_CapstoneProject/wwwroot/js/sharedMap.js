let map;
let marker;
let geocoder;
let responseDiv;
let response;




function initMap() {
    map = new google.maps.Map(document.getElementById("sharedMap"),
        {
            zoom: 15,
            center: { lat: -34.397, lng: 150.644 },
            mapTypeControl: false,
        });
    geocoder = new google.maps.Geocoder();

    const addressToGeocode = document.getElementById("eventLocation");



    marker = new google.maps.Marker({
        map,
    });

    addressToGeocode.addEventListener("click",
        () =>
            geocode({ address: addressToGeocode.textContent }
    ));

    //document.addEventListener("DOMContentLoaded", () => {
    //    geocode({ address: addressToGeocode.value });
    //});


}

function unhideMap() {


    var x = document.getElementById("sharedMap");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function clear() {
    marker.setMap(null);
}

function geocode(request) {
    clear();
    geocoder
        .geocode(request)
        .then((result) => {
            const { results } = result;

            map.setCenter(results[0].geometry.location);
            marker.setPosition(results[0].geometry.location);
            marker.setMap(map);
            response.innerText = JSON.stringify(result, null, 2);
            return results;
        });

}

const eventLocation = document.getElementById("eventLocation");

if (eventLocation.textContent) {

    document.addEventListener("DOMContentLoaded", () => {
        geocode({ address: eventLocation.textContent });
    });
} else {
    window.initMap = initMap;
}
