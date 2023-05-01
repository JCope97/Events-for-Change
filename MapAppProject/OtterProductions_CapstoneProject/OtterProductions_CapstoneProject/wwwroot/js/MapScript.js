// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Initialize and add the map
/**
 * @license
 * Copyright 2019 Google LLC. All Rights Reserved.
 * SPDX-License-Identifier: Apache-2.0
 */
let map;
let marker;
let geocoder;
let responseDiv;
let response;
let markers = [];


function initMap() {
    map = new google.maps.Map(document.getElementById("map"),
        {
            zoom: 13,
            center: { lat: -34.397, lng: 150.644 },
            mapTypeControl: false,
        });
    geocoder = new google.maps.Geocoder();

    const inputText = document.getElementById("location");

    const submitButton = document.getElementById("submit");

    const restroomButton = document.getElementById("restroom");
    const foodBankButton = document.getElementById("Food Bank");
    const shelterButton = document.getElementById("Shelter");
    const listtitle = document.getElementById("list-title");
    const getLocationButton = document.getElementById("locationButton");
    

    const clearButton = document.createElement("input");

    const service = new google.maps.places.PlacesService(map);

    let getNextPage;

    const moreButton = document.getElementById("more");

    moreButton.onclick = function() {
        moreButton.disabled = true;
        if (getNextPage) {
            getNextPage();
        }
    };

    clearButton.type = "button";
    clearButton.value = "Clear";
    clearButton.classList.add("button", "button-secondary");
    response = document.createElement("pre");
    response.id = "response";
    response.innerText = "";
    //responseDiv = document.createElement("div");
    //responseDiv.id = "response-container";
    //responseDiv.appendChild(response);

    //const instructionsElement = document.createElement("p");

    //instructionsElement.id = "instructions";
    //instructionsElement.innerHTML =
    //    "<strong>Instructions</strong>: Enter an address in the textbox to geocode or click on the map to reverse geocode.";
    //map.controls[google.maps.ControlPosition.TOP_LEFT].push(inputText);
    //map.controls[google.maps.ControlPosition.TOP_LEFT].push(submitButton);
    //map.controls[google.maps.ControlPosition.TOP_LEFT].push(clearButton);
    //map.controls[google.maps.ControlPosition.LEFT_TOP].push(
    //    instructionsElement
    //);
/*    map.controls[google.maps.ControlPosition.LEFT_TOP].push(responseDiv);*/
    marker = new google.maps.Marker({
        map,
    });
    map.addListener("click",
        (e) => {
            geocode({ location: e.latLng });
        });
    submitButton.addEventListener("click",
        () =>
        geocode({ address: inputText.value })
    );
    clearButton.addEventListener("click",
        () => {
            clear();
        });
    clear();

    restroomButton.addEventListener("click",
        () => {
            if (firstLocation.value) {
                deleteMarkers();

                service.nearbySearch(
                    { location: map.center, radius: 900, keyword: "Bathroom", minPriceLevel: 0, maxPriceLevel: 0 },
                    (results, status, pagination) => {
                        if (status !== "OK" || !results) return;

                        addPlaces(results, map);
                        listtitle.innerHTML = "Restrooms";

                        //new stuff
                        moreButton.disabled = !pagination || !pagination.hasNextPage;
                        if (pagination && pagination.hasNextPage) {
                            getNextPage = () => {
                                // Note: nextPage will call the same handler function as the initial call
                                pagination.nextPage();
                                };
                            }
                        });
            } else {
                alert("Please enter an address or city");
            }

            
        });

    foodBankButton.addEventListener("click",
        () => {
            if (firstLocation.value) {
                deleteMarkers();

                service.nearbySearch(
                    { location: map.center, radius: 900, keyword: "Food Bank", minPriceLevel: 0, maxPriceLevel: 0 },
                    (results, status, pagination) => {
                        if (status !== "OK" || !results) return;

                        addPlaces(results, map);
                        listtitle.innerHTML = "Food Banks";


                        //new stuff
                        moreButton.disabled = !pagination || !pagination.hasNextPage;
                        if (pagination && pagination.hasNextPage) {
                            getNextPage = () => {
                                // Note: nextPage will call the same handler function as the initial call
                                pagination.nextPage();
                                };
                            }
                        });
            } else {
                alert("Please enter an address or city");
            }

            
        });

    shelterButton.addEventListener("click",
        () => {
            if (firstLocation.value) {
                deleteMarkers();
                service.nearbySearch(
                    { location: map.center, radius: 900, keyword: "shelter", minPriceLevel: 0, maxPriceLevel: 0 },
                    (results, status, pagination) => {
                        if (status !== "OK" || !results) return;

                        addPlaces(results, map);
                        listtitle.innerHTML = "Shelters";


                        //new stuff
                        moreButton.disabled = !pagination || !pagination.hasNextPage;
                        if (pagination && pagination.hasNextPage) {
                            getNextPage = () => {
                                // Note: nextPage will call the same handler function as the initial call
                                pagination.nextPage();
                                };
                            }
                        });
            } else {
                alert("Please enter an address or city");
            }

        });


    

    getLocationButton.addEventListener("click",
        () => {
            getLocationMap(geocoder);
        });

}

function getLocationMap() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(geocodeLatLongMap);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function geocodeLatLongMap(position) {

    const latlng = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
    };
    const inputText = document.getElementById("location");


    geocoder
        .geocode({ location: latlng })
        .then((response) => {
            if (response.results[0]) {
                inputText.value = response.results[0].formatted_address;
            }
        });
};

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
        })
        .catch((e) => {
            alert("That was not a valid address. Error:" + e);
        });
}





function addPlaces(places, map) {
    const placesList = document.getElementById("places");
    const getMoreButton = document.getElementById("more");
    for (const place of places) {
        if (place.geometry && place.geometry.location) {
            const image = {
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25),
            };

            const placeMarker = new google.maps.Marker({
                map,
                icon: image,
                title: place.name,
                position: place.geometry.location,
            });

            markers.push(placeMarker);
           /* new stuff*/
            const li = document.createElement("li");

            li.textContent = place.name;
            li.id = "placesitem";
            placesList.appendChild(li);
            getMoreButton.hidden = "";
            li.addEventListener("click", () => {
                map.setCenter(place.geometry.location);
            });
        }
    }
}

function hideMarkers() {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(null);

    }
}

function deleteMarkers() {
    hideMarkers();
    markers = [];
    const placesList = document.getElementById("places");
    placesList.replaceChildren();


}




/*window.initMap = initMap;*/

const firstLocation = document.getElementById("location");

if (firstLocation.value ){

    document.addEventListener("DOMContentLoaded", () => {
        geocode({ address: firstLocation.value });
    });
} else {
    window.initMap = initMap;
}

