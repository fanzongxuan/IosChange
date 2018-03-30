var $table = $("#checklist-grid");
var TableInit = function () {
    var oTable = new Object();
    oTable.QueryUrl = '/Account/ListJson' + '?rnd=' + +Math.random();
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
                { field: "AppId", title: "账号" }, 
                { field: "Password", title: "密码" },
                { field: "UseTime", title: "总使用次数" },
                {
                    field: "Id",
                    title: "操作",
                    formatter: function (value, row, index) {
                        a = "<a class='delete' style='margin-right:15px' href='javascript:void(0)'>删除</a>"
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
            pageSize: params.pageSize,
            pageIndex: params.pageNumber - 1,
            FormTime: $("#StartLine").val(),
            ToTime: $("#EndLine").val(),
            AppId:$("#AppId").val()
        };
        return data;
    }

    return oTable;
}
window.operateEvents = {
    'click .delete': function (e, value, row, index) {
        if (confirm("是否删除?")) {
            $.ajax({
                type: "get",
                url: '/account/delete/' + value + '',
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
});

//查询
$("#search").click(function () {
    $table.bootstrapTable('refreshOptions', { pageNumber: 1 });
});
