using System;
using System.Text;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class SortableHelper
    {
        public static string Sortable_Task_Board(Sortable_BoardModel model)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<div id='stage_{0}' class='task-board h-100 radius-2px bgc-secondary-l4 py-2 px-25 border-t-2 {1}' data-id='{0}' data-type='{2}' data-stage='{3}' data-title='{4}'>", model.Id, model.BoardClass, model.Group, model.BoardType, model.Title));

            html.AppendLine("<div class='d-flex align-items-center'>");

            html.AppendLine(string.Format("<h5 class='text-secondary-d3 m-2 mb-3 pb-1'><i class='text-80 fa fa-list text-dark-tp3 mr-1'></i> {0} </h5>", model.Title));

            html.AppendLine("<div class='dropdown'>");

            html.AppendLine(string.Format("<button class='ml-auto btn {1} btn-sm btn-bold dropdown-toggle border-0' type='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' id='board_{0}'><i class='fa fa-ellipsis-h'></i></button>", model.Id, model.ButtonClass));

            html.AppendLine("<div class='dropdown-menu' aria-labelledby='board_{0}'>");

            html.AppendLine(string.Format("<a class='dropdown-item btnNewItemBoard' href='javascript:void(0)' idata='{0}' idata-stage='{1}'> <i class='fa fa-plus'></i> Thêm nhiệm vụ </a>", model.Id, model.BoardType));

            html.AppendLine(string.Format("<a class='dropdown-item btnStoreItemBoard' href='javascript:void(0)' idata='{0}' idata-stage='{1}'> <i class='fa fa-save'></i> Lưu trữ tất cả </a>", model.Id, model.BoardType));

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            //Phần item
            // html.AppendLine(string.Format("<div class='boxTaskContent' data-id='{0}' data-type='{1}' data-stage='{2}' data-title='{3}'>", model.Id, model.Group, model.BoardType, model.Title));

            foreach (var item in model.Items)
            {
                html.AppendLine(Sortable_Task_Item(item));
            }

            // html.AppendLine("</div>");

            html.AppendLine("<div class='task-item boxRenderItem' style='height:20px; margin-bottom: 16px'></div>");

            html.AppendLine("<div style='position:absolute; bottom: 10px; right: 16px; left: 16px'>");

            html.AppendLine(string.Format("<button class='btn btn-smd btn-outline-grey btn-h-outline-grey btn-a-outline-grey btn-block border-0 btnNewItemBoardFromFooter' idata='{0}' type='button'><i class='fa fa-plus'></i> Thêm mới </button>", model.Id));

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            return html.ToString();
        }

        public static string Sortable_Task_Item(Sortable_ItemModel model)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<div class='task-item mb-25 radius-3px border-1 bgc-white brc-secondary-l1 px-2 pt-3 pb-3 pos-rel' data-id='{0}' data-type='{1}' data-title='{2}'>", model.Id, model.Group, model.Title));

            #region MyRegion

            html.AppendLine("<div class='pl-1'>");

            html.AppendLine(string.Format("<div class='text-400 text-blue-d2 text-90'>{0}</div>", model.Title));

            html.AppendLine(string.Format("<div class='text-400 text-purple-d2 text-80'>{0}</div>", model.Description));

            html.AppendLine(string.Format("<div class='text-400 text-90 text-task-span'>{0}</div>", model.htmlSubTitle));

            html.AppendLine("</div>");
            #endregion

            html.AppendLine("<div class='d-flex'>");

            html.AppendLine("<div></div>");

            html.AppendLine("<div class='align-self-end'></div>");

            html.AppendLine("<div class='py-1 position-tr mt-n2 mr-n1'>");

            html.AppendLine("<div class='dropdown dd-backdrop dd-backdrop-none-md'>");

            html.AppendLine("<a class='btn btn-outline-default btn-h-outline-primary btn-brc-tp btn-xs btn-text-slide-x dropdown-toggle' href='javascript:void(0)' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'><i class='fa fa-ellipsis-h btn-text-2'></i></a>");

            #region MyRegion
            //-- NÚT ẤN

            html.AppendLine("<div class='dropdown-menu mw-auto dropdown-caret dropdown-menu-right dropdown-animated animated-1 dd-slide-center dd-slide-none-md'>");

            html.AppendLine("<div class='dropdown-inner'>");

            html.AppendLine(string.Format("<a class='dropdown-item btnViewRecord' href='javascript:void(0)' title='Sửa nhiệm vụ' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-edit text-info mx-1'></i></a>", model.Id));

            html.AppendLine(string.Format("<a class='dropdown-item btnRemoveRecord' href='javascript:void(0)' title='Xóa nhiệm vụ' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-trash text-danger mx-1'></i></a>", model.Id));

            html.AppendLine(string.Format("<a class='dropdown-item btnHideRecord' href='javascript:void(0)' title='Lưu trữ nhiệm vụ' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-save text-purple mx-1'></i></a>", model.Id));

            if (model.IsSubscribe)
                html.AppendLine(string.Format("<a class='dropdown-item btnSubscribe' href='javascript:void(0)' title='Bỏ theo dõi thẻ để ngừng nhận thông báo khi có thay đổi' data-toggle='tooltip' idata-subscribe='{0}' data-placement='left' idata='{0}'><i class='fa fa-eye text-purple mx-1'></i></a>", model.Id));
            else
                html.AppendLine(string.Format("<a class='dropdown-item btnSubscribe' href='javascript:void(0)' title='Theo dõi thẻ để nhận thông báo khi có thay đổi' data-toggle='tooltip' idata-subscribe='{0}' data-placement='left' idata='{0}'><i class='fa fa-eye-slash text-purple mx-1'></i></a>", model.Id));

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            //--
            #endregion

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            return html.ToString();
        }

        public static string Sortable_Project_Board(Sortable_BoardModel model, bool isHaveAddNew = true)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<div id='stage_{0}' class='project-board h-100 radius-2px bgc-secondary-l4 py-2 px-25 border-t-2 {1}' data-id='{0}' data-type='{2}' data-stage='{3}'>", model.Id, model.BoardClass, model.Group, model.BoardType));

            html.AppendLine("<div class='d-flex align-items-center'>");

            html.AppendLine(string.Format("<h5 class='text-secondary-d3 m-2 mb-3 pb-1'><i class='text-80 fa fa-list text-dark-tp3 mr-1'></i> {0} </h5>", model.Title));

            html.AppendLine("<div class='dropdown'>");

            html.AppendLine(string.Format("<button class='ml-auto btn {1} btn-sm btn-bold dropdown-toggle border-0' type='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' id='board_{0}'><i class='fa fa-ellipsis-h'></i></button>", model.Id, model.ButtonClass));

            html.AppendLine("<div class='dropdown-menu' aria-labelledby='board_{0}'>");

            if (isHaveAddNew)
            {
                html.AppendLine(string.Format("<a class='dropdown-item btnNewItemBoard' href='javascript:void(0)' idata='{0}' idata-stage='{1}'> <i class='fa fa-plus'></i> Thêm dự án </a>", model.Id, model.BoardType));
            }

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            //Phần item
            // html.AppendLine(string.Format("<div class='boxProjectContent' data-id='{0}' data-type='{1}' data-stage='{2}'>", model.Id, model.Group, model.BoardType));

            foreach (var item in model.Items)
            {
                html.AppendLine(Sortable_Project_Item(item));
            }

            // html.AppendLine("</div>");

            html.AppendLine("<div class='task-item boxRenderItem' style='height:20px; margin-bottom: 16px'></div>");

            html.AppendLine("<div style='position:absolute; bottom: 10px; right: 16px; left: 16px'>");

            if (isHaveAddNew)
            {
                html.AppendLine(string.Format("<button class='btn btn-smd btn-outline-grey btn-h-outline-grey btn-a-outline-grey btn-block border-0 btnNewItemBoardFromFooter' idata='{0}' type='button'><i class='fa fa-plus'></i> Thêm mới </button>", model.Id));
            }

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            return html.ToString();
        }

        public static string Sortable_Project_Item(Sortable_ItemModel model)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<div class='task-item mb-25 radius-3px border-1 bgc-white brc-secondary-l1 px-2 pt-3 pb-3 pos-rel' data-id='{0}' data-type='{1}'>", model.Id, model.Group));

            #region MyRegion

            html.AppendLine("<div class='pl-1'>");

            html.AppendLine(string.Format("<div class='text-400 text-blue-d2 text-90'>{0}</div>", model.Title));

            html.AppendLine(string.Format("<div class='text-400 text-purple-d2 text-80'>{0}</div>", model.Description));

            html.AppendLine(string.Format("<div class='text-400 text-90 text-task-span'>{0}</div>", model.htmlSubTitle));

            html.AppendLine("</div>");
            #endregion

            html.AppendLine("<div class='d-flex'>");

            html.AppendLine("<div></div>");

            html.AppendLine("<div class='align-self-end'></div>");

            html.AppendLine("<div class='py-1 position-tr mt-n2 mr-n1'>");

            html.AppendLine("<div class='dropdown dd-backdrop dd-backdrop-none-md'>");

            html.AppendLine("<a class='btn btn-outline-default btn-h-outline-primary btn-brc-tp btn-xs btn-text-slide-x dropdown-toggle' href='javascript:void(0)' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'><i class='fa fa-ellipsis-h btn-text-2'></i></a>");

            #region MyRegion
            //-- NÚT ẤN

            html.AppendLine("<div class='dropdown-menu mw-auto dropdown-caret dropdown-menu-right dropdown-animated animated-1 dd-slide-center dd-slide-none-md'>");

            html.AppendLine("<div class='dropdown-inner'>");

            html.AppendLine(string.Format("<a class='dropdown-item btnViewRecord' href='javascript:void(0)' title='Sửa dự án' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-edit text-info mx-1'></i></a>", model.Id));

            html.AppendLine(string.Format("<a class='dropdown-item btnRemoveRecord' href='javascript:void(0)' title='Xóa dự án' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-trash text-danger mx-1'></i></a>", model.Id));

            html.AppendLine(string.Format("<a class='dropdown-item btnHideRecord' href='javascript:void(0)' title='Lưu trữ dự án' data-toggle='tooltip' data-placement='left' idata='{0}'><i class='fa fa-save text-purple mx-1'></i></a>", model.Id));

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            //--
            #endregion

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            html.AppendLine("</div>");

            return html.ToString();
        }

        public static string RenderSpanDate(DateTime time, bool isCompleted = false)
        {
            var format = string.Format("<span class='{1}'><i class='fa fa-clock mr-2px'></i> {0} </span>", time.ToString("dd/MM/yyyy HH:mm"), isCompleted ? "badge bgc-success-l2 text-success-d3" : "");

            return format;
        }

        public static string RenderSpanStartEndDate(DateTime startTime, DateTime endTime, string completeTime = "", bool isCompleted = false, bool isInProgress = false)
        {
            if (isCompleted && completeTime!="")
            {
                DateTime CompleteTime = DateTime.Parse(completeTime);
                // Định dạng hiển thị thời gian
                string strCompleteTime = CompleteTime.ToString("dd/MM");
                if (CompleteTime.Year != DateTime.Now.Year)
                    strCompleteTime = CompleteTime.ToString("dd/MM/yyyy");

                var format = string.Format("<span class='{1}' style='margin-left:0px!important'><i class='fa fa-clock mr-2px'></i> {0} </span>", strCompleteTime, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "");

                return format;
            }
            else
            {
                if (isInProgress)
                {
                    // Định dạng hiển thị thời gian
                    string strEndTime = endTime.ToString("dd/MM");
                    if (endTime.Year != DateTime.Now.Year)
                        strEndTime = endTime.ToString("dd/MM/yyyy");

                    if (endTime < DateTime.Now)
                    {
                        var format1 = string.Format("<span class='{1}' style='margin-left:0px!important'><i class='fa fa-clock mr-2px'></i> {0} </span>", strEndTime, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "badge bgc-danger-l2 text-danger-d3 mr-2px");

                        return format1;
                    }

                    if (endTime < DateTime.Now.AddDays(7))
                    {
                        var format1 = string.Format("<span class='{1}' style='margin-left:0px!important'><i class='fa fa-clock mr-2px'></i> {0} </span>", strEndTime, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "badge bgc-warning-l2 text-warning-d3 mr-2px");

                        return format1;
                    }

                    var format = string.Format("<span class='{1}' style='margin-left:0px!important'><i class='fa fa-clock mr-2px'></i> {0} </span>", strEndTime, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "badge bgc-secondary-l2 text-secondary-d3 mr-2px");

                    return format;
                }
            }

            return "";
        }

        public static string RenderSpanSubscribe(bool IsSubscribe, string taskId)
        {
            if (IsSubscribe)
                return string.Format("<span class='' style='margin-left:0px!important' idata-icon-subscribe='{0}' ><i class='fa fa-eye mr-2px'></i></span>", taskId);
            else
                return string.Format("<span class='' style='margin-left:0px!important' idata-icon-subscribe='{0}'><i class='fa'></i></span>", taskId);

        }

        public static string RenderSpanProcess(int complete, int total, bool isCompleted = false)
        {
            if (total == 0)
            {
                return "";
            }

            var format = string.Format("<span class='{2}'><i class='fa fa-check-square mr-2px'></i> {0}/{1} </span>", complete, total, (isCompleted || ((complete == total) && total > 0)) ? "badge bgc-success-l2 text-success-d3 mr-2px" : "");

            return format;
        }

        public static string RenderSpanUser(int complete, int total, bool isCompleted = false)
        {
            if (total == 0)
            {
                return "";
            }

            var format = string.Format("<span class='{1}'><i class='fa fa-users mr-2px'></i> {0} </span>", total, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "");

            return format;
        }

        public static string RenderSpanTag(int complete, int total, bool isCompleted = false)
        {
            if (total == 0)
            {
                return "";
            }

            var format = string.Format("<span class='{1}'><i class='fa fa-user-tag mr-2px'></i> {0} </span>", total, isCompleted ? "badge bgc-success-l2 text-success-d3 mr-2px" : "");

            return format;
        }

        public static string RenderOwner(string account_email, string employee_email, string display)
        {
            if (account_email == employee_email)
            {
                return "";
            }

            var format = string.Format("<span class='{1} ml-0'> {0} </span>", display, "badge bgc-grey-l2 text-grey-d3");

            return format;
        }
    }
}
