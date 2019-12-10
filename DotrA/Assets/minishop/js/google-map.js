var map;
function initMap() {
    map = new google.maps.Map(
        document.getElementById('map'),
        { center: new google.maps.LatLng(25.0420753, 121.5361051), zoom: 14 });

    new google.maps.Marker({
        position: new google.maps.LatLng(25.0420753, 121.5361051),
        icon: '/Assets/minishop/images/map-icon.png',
        map: map,
        title: '地址'
    });
}