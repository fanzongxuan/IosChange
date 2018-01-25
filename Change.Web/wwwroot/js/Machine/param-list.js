var $table = $("#checklist-grid");
var TableInit = function () {
    var oTable = new Object();
    oTable.QueryUrl = '/Machine/ParamListJson' + '?rnd=' + +Math.random();
    oTable.Init = function () {
        $table.bootstrapTable({
            method: 'post',
            striped: true,      //是否显示行间隔色
            cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,     //是否显示分页（*）
            sortable: true,      //是否启用排序           
            pageNumber: 1,      //初始化加载第一页，默认第一页
            pageSize: 10,      //每页的记录行数（*）
            pageList: [10, 30, 50],  //可供选择的每页的行数（*）
            url: oTable.QueryUrl,//这个接口需要处理bootstrap table传递的固定参数
            queryParamsType: '', //默认值为 'limit' ,在默认情况下 传给服务端的参数为：offset,limit,sort
            // 设置为 '' 在这种情况下传给服务器的参数为：pageSize,pageNumber
            queryParams: oTable.queryParams,//前端调用服务时，会默认传递上边提到的参数，如果需要添加自定义参数，可以自定义一个函数返回请求参数
            sidePagination: "server",   //分页方式：client客户端分页，server服务端分页（*）
            showExport: true,                     //是否显示导出
            exportDataType: "basic",
            showRefresh: true,
            showToggle: true,

            showColumns: true,
            exportTypes: ['excel'],
            columns: [
                { field: "CreateTime", title: "创建时间" },
                { field: "Name", title: "设备名称" },
                //{ field: "LocalName", title: "设备本地名称" },
                //{ field: "SystemName", title: "设备系统名称" },
                { field: "DeviceModelName", title: "设备机型" },
                //{ field: "UUID", title: "UUID" },
                //{ field: "IDFV", title: "IDFV" },
                { field: "SystemVersion", title: "系统版本" },
                //{ field: "IDFA", title: "IDFA" },
                { field: "MAC", title: "MAC" },
                //{ field: "Type", title: "手机类型" },
                //{ field: "Resolution", title: "分辨率" },
                //{ field: "ResolutionZoom", title: "分辨率缩放" },
                //{ field: "CarrierName", title: "运营商" },
                //{ field: "BatteryStatusName", title: "电池状态" },
                //{ field: "BatteryLevel", title: "电池电量" },
                //{ field: "MachineTag", title: "设备标签" },
                //{ field: "ScreenBrightness", title: "屏幕亮度" },
                //{ field: "WifiName", title: " Wifi名称" },
                //{ field: "NetWorkTypeName", title: "联网类型" },
                //{ field: "LocalLanguage", title: "本地语言" },
                { field: "IMEI", title: "IMEI" },
                //{ field: "SaleArea", title: "销售地区" },
                {
                    field: "Enable",
                    title: "是否启用",
                    formatter: function (value, row, index) {
                        var str = ""
                        if (value == true)
                            str = "<span class='label label-success'>已启用</span>"
                        if (value == false)
                            str = "<span class='label label-danger'>未启用</span>"
                        return str
                    },
                    align: "center",
                },
                {
                    field: "Id",
                    title: "操作",
                    formatter: function (value, row, index) {
                        a = "<a style='margin-right:15px' href='/machine/DetailParam/" + value + "'>详情</a><a class='delete' style='margin-right:15px' href='javascript:void(0)'>删除</a>"
                        if (row["Enable"] == false) {
                            a += "<a class='enable' href='javascript:void(0)' >启用</a>";
                        }
                        return a;
                    },
                    align: "center",
                    events: 'operateEvents'
                }
            ]
        });
    }
    oTable.queryParams = function (params) {
        var data = {
            PageSize: params.pageSize,
            PageIndex: params.pageNumber - 1,
            FormTime: $("#StartLine").val(),
            ToTime: $("#EndLine").val(),
            MachineId: parseInt($("#machineId").val())
        };
        return data;
    }

    return oTable;
}
window.operateEvents = {
    'click .enable': function (e, value, row, index) {
        if (confirm("是否启用该条自定义参数?")) {
            $.ajax({
                type: "get",
                url: '/machine/EnableMachineParam/' + value + '?enable=true',
                success: function (data) {
                    if (data["code"] == 1) {
                        $table.bootstrapTable('refresh', { field: 'Id', values: [row.Id] });
                    } else {
                        alert(data['message']);
                    }
                }
            });
        }
    },
    'click .delete': function (e, value, row, index) {
        if (confirm("是否删除?")) {
            $.ajax({
                type: "get",
                url: '/machine/DeleteParam/' + value + '',
                success: function (data) {
                    if (data["code"] == 1) {
                        $table.bootstrapTable('remove', { field: 'Id', values: [row.Id] });
                    } else {
                        alert(data['message']);
                    }
                }
            });
        }
    }
};


//初始化表格
$(function () {
    var myTable = new TableInit();
    myTable.Init();

    $("#quick-generate").click(function () {
        $.ajax({
            type: "get",
            url: '/machine/quickgenerate?machineId=' + $("#machineId").val() + '',
            success: function (data) {
                if (data["code"] == 1) {
                    $table.bootstrapTable('refresh');
                } else {
                    alert(data['message']);
                }
            }
        });
    })
});

//查询
$("#search").click(function () {
    $table.bootstrapTable('refreshOptions', { pageNumber: 1 });
});
