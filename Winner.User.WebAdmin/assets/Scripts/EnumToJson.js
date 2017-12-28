
window.enumCollection={
	DocsType : [
		["身份证" , 1],
	],
	eBankAccountType : [
		["积分" , 1],
		["爱心" , 2],
		["E币" , 3],
		["现金" , 4],
	],
	IdentityValidateType : [
		["短信验证" , 1],
		["旧密码验证" , 2],
	],
	ValidateStatus : [
		["审核中" , 1],
		["审核通过" , 2],
		["审核未通过" , 4],
		["已删除" , 8],
	],
}

 function renderEnum(type,value){
     var array = window.enumCollection[type];
     if (!array) {
         return value;
     }
     for (var i in array) {
         if (array[i][1] == value) {
             return array[i][0]
         }
     }
 }
 ;(function($){
	$.fn.extend({
		bindEnum:function(type,defaultItem){
			var array = window.enumCollection[type];
			if(!array){
				return $(this);
			}
			var tag = $(this).get(0).tagName;					
			for(var i in array){
				var option = $("<option></option>");	
				option.val(array[i][1]).text(array[i][0]);
				$(this).append(option);
			}
			if (typeof defaultItem == 'int') {
			    $(this).find("option[value=" + defaultItem + "]").attr("selected", "selected");
			}
			if (typeof defaultItem == 'object') {
			    var defaultoption = $("<option selected='selected'></option>").val(defaultItem.value).text(defaultItem.text);
			    $(this).append(defaultoption);
			}
			return $(this);
		},
        remoteBind: function (json) {
            var $this = $(this);
            $.ajax({
                url: json.url,
                data: json.data,
                type: "POST",
                success: function (res) {
                    if (res.Success) {
                        if (res.Content && res.Content.Data && res.Content.Data.length > 0) {
                            $this.append($("<option value='-1' selected='selected'>===所有===</option>"));
                            for (var i in res.Content.Data) {
                                var item = res.Content.Data[i];
                                var option = $("<option></option>");
                                option.val(item.value).text(item.text);
                                $this.append(option);
                            }
                        }
                    } else {
                        var err = $("<option></option>");
                        err.val(-1).text(res.Message).attr("selected", "selected");
                        $this.append(err);
                    }
                },
                error: function () {

                }
            });
        }
	});
 })(jQuery);
