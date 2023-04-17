var newGeocoder;

function initialize() {

    newGeocoder = new google.maps.Geocoder();
    const getLocationButton = document.getElementById("locationButton");

    getLocationButton.addEventListener("click",
        () => {
            getLocation(newGeocoder);
        });

}

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(geocodeLatLong);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function geocodeLatLong(position) {

    

    const latlng = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
    };
    const addressText = document.getElementById("address");


    newGeocoder
        .geocode({ location: latlng })
        .then((response) => {
            if (response.results[0]) {
                addressText.value = response.results[0].formatted_address;
            }
        });
};