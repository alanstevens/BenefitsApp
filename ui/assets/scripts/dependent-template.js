(function() {
  var template = Handlebars.template, templates = Handlebars.templates = Handlebars.templates || {};
templates['dependent.hbs'] = template({"compiler":[7,">= 4.0.0"],"main":function(container,depth0,helpers,partials,data) {
    var helper, alias1=depth0 != null ? depth0 : (container.nullContext || {}), alias2=helpers.helperMissing, alias3="function", alias4=container.escapeExpression;

  return "<!-- Dependent Element  -->\n<div class=\"row dependent\">\n    <div class=\"col-sm-4 \" style=\"text-align:right\">Dependent: </div>\n    <div class=\"col-sm-8 border\">\n        <div class=\"row\">\n            <div class=\"col-sm-8\" style=\"text-align:right\">Benefits Cost:</div>\n            <div class=\"col-sm-4\">Annual</div>\n        </div>\n        <div class=\"row\">\n            <div class=\"col-sm-4\" >"
    + alias4(((helper = (helper = helpers.firstName || (depth0 != null ? depth0.firstName : depth0)) != null ? helper : alias2),(typeof helper === alias3 ? helper.call(alias1,{"name":"firstName","hash":{},"data":data}) : helper)))
    + "</div>\n            <div class=\"col-sm-4\" >"
    + alias4(((helper = (helper = helpers.lastName || (depth0 != null ? depth0.lastName : depth0)) != null ? helper : alias2),(typeof helper === alias3 ? helper.call(alias1,{"name":"lastName","hash":{},"data":data}) : helper)))
    + "</div>\n            <div class=\"col-sm-4\" >"
    + alias4(((helper = (helper = helpers.personalBenefitsCost || (depth0 != null ? depth0.personalBenefitsCost : depth0)) != null ? helper : alias2),(typeof helper === alias3 ? helper.call(alias1,{"name":"personalBenefitsCost","hash":{},"data":data}) : helper)))
    + "</div>\n        </div>\n    </div>\n</div>\n<!-- End Dependent Element  -->\n";
},"useData":true});
})();