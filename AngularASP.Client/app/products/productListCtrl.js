(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ["productResource", ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        productResource.query({ $filter: "substringof('GDN',ProductCode)" }, function (data) {
            vm.products = data;
        });
    }
}());

