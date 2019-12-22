jQuery(function () {
    jQuery('#bootstrap-data-table').DataTable({
        lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "All"]],
        language: {
            url: "/Assets/ElaAdmin/js/lib/data-table/Chinese-traditional.json"
        }
    });
});
