using System;
using System.Collections.Generic;
using System.Text;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class KanbanHelper
    {
        public static KanbanModel RenderBoard(string idBoard, string titleBoard, string htmlSummary, string cssBoard, List<KanbanItemModel> items, bool isHaveButton = false, string cssButton = "btn-outline-success", bool isHaveAddNewItem = false, bool isHaveEditBoard = false, bool isHaveRemoveBoard = false)
        {
            var model = new KanbanModel()
            {
                id = idBoard,
                title = RenderBoardTitle(idBoard, titleBoard, isHaveButton, cssButton, isHaveAddNewItem, isHaveEditBoard, isHaveRemoveBoard),
                classname = cssBoard,
                item = items,
                summary = !string.IsNullOrWhiteSpace(htmlSummary) ? htmlSummary : ""
            };

            return model;
        }

        private static string RenderBoardTitle(string idBoard, string title, bool isHaveButton = false, string cssButton = "btn-outline-success", bool isHaveAddNewItem = false, bool isHaveEditBoard = false, bool isHaveRemoveBoard = false)
        {
            var html = new StringBuilder();

            //html.AppendLine("<div class='d-flex align-items-center'>");
            html.AppendLine(string.Format("<h5 class='text-secondary-d3 m-2 mb-3 pb-1'> <i class='text-80 fa fa-list text-dark-tp3 mr-1'></i> <span>{0}</span> </h5>", title));
            

            //Nút
            if (isHaveButton)
            {
                //html.AppendLine("<div class='dropdown dd-backdrop dd-backdrop-none-md'>");

                html.AppendLine(string.Format("<button type='button' class='ml-auto btn {0} btn-sm btn-bold dropdown-toggle border-0' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>", cssButton));

                html.AppendLine("<i class='fa fa-ellipsis-h'></i>");

                html.AppendLine("</button>");

                html.AppendLine("<div class='dropdown-menu mw-auto dropdown-caret dropdown-menu-right dropdown-animated animated-1 dd-slide-center dd-slide-none-md'>");

                if (isHaveAddNewItem)
                {
                    html.AppendLine("<div class='dropdown-inner'>");

                    html.AppendLine(string.Format("<a class='dropdown-item btnNewItemBoard' href='javascript:void(0)' title='Thêm mới' idata='{0}'><i class='fa fa-plus text-success mx-1'></i></a>", idBoard));

                    html.AppendLine("</div>");
                }

                if (isHaveEditBoard)
                {

                    html.AppendLine("<div class='dropdown-inner'>");

                    html.AppendLine(string.Format("<a class='dropdown-item btnEditBoard' href='javascript:void(0)' title='Sửa' idata='{0}'><i class='fa fa-edit text-blue mx-1'></i></a>", idBoard));

                    html.AppendLine("</div>");
                }

                if (isHaveRemoveBoard)
                {
                    html.AppendLine("<div class='dropdown-inner'>");

                    html.AppendLine(string.Format("<a class='dropdown-item btnRemoveBoard' href='javascript:void(0)' title='Xóa' idata='{0}'><i class='fa fa-trash text-danger mx-1'></i></a>", idBoard));

                    html.AppendLine("</div>");
                }

                html.AppendLine("</div>");

                //html.AppendLine("</div>");
            }

            //html.AppendLine("</div>");

            return html.ToString();
        }

        public static string RenderBoardItemTitle(string htmlContent, bool isHaveActionItem = false, bool isHaveActionDelete = false, string recordid = "")
        {
            var html = new StringBuilder();

            html.AppendLine("<div class='pl-1'>");
            html.AppendLine(string.Format("{0}", htmlContent));
            
            html.AppendLine("</div>");

            if (isHaveActionItem)
            {
                html.AppendLine("<div class='d-flex'>");
                html.AppendLine("<div class='align-self-end'></div>");

                html.AppendLine("<div class='py-1 position-tr mt-n2 mr-n1'>");

                html.AppendLine("<div class='dropdown dd-backdrop dd-backdrop-none-md'>");

                html.AppendLine("<a class='btn btn-outline-default btn-h-outline-primary btn-brc-tp btn-xs dropdown-toggle' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'><i class='fa fa-ellipsis-h'></i></a>");

                html.AppendLine("<div class='dropdown-menu mw-auto dropdown-caret dropdown-menu-right dropdown-animated animated-1 dd-slide-center dd-slide-none-md'>");


                html.AppendLine("<div class='dropdown-inner'>");

                html.AppendLine(string.Format("<a class='dropdown-item btnViewRecord' href='javascript:void(0)' title='Xem chi tiết' idata='{0}'><i class='fa fa-edit text-blue mx-1'></i><span class='d-md-none'>View record</span></a>", recordid));

                html.AppendLine("</div>");

                html.AppendLine("<div class='dropdown-inner'>");

                html.AppendLine(string.Format("<a class='dropdown-item btnHideRecord' href='javascript:void(0)' title='Ẩn không theo dõi' idata='{0}'><i class='fa fa-eye-slash text-purple mx-1'></i><span class='d-md-none'>Hide record</span></a>", recordid));

                html.AppendLine("</div>");

                if (isHaveActionDelete)
                {
                    html.AppendLine("<div class='dropdown-inner'>");

                    html.AppendLine(string.Format("<a class='dropdown-item btnRemoveRecord' href='javascript:void(0)' title='Delete record' idata='{0}'><i class='fa fa-trash text-danger mx-1'></i><span class='d-md-none'>Delete record</span></a>", recordid));

                    html.AppendLine("</div>");
                }

                html.AppendLine("</div>");

                html.AppendLine("</div>");

                html.AppendLine("</div>");
            }

            return html.ToString();
        }

        public static string RenderBoardItemContent(string title, string subtitle, string description)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<div class= 'text-600 text-blue-d2 text-95'>{0}</div>", title));
            html.AppendLine(string.Format("<div class= 'text-600 text-warning-d2 text-85'>{0}</div>", subtitle));
            html.AppendLine(string.Format("<div class= 'text-600 text-purple-d2 text-80'>{0}</div>", description));

            return html.ToString();
        }

        public static string RenderBoardSummary(string content)
        {
            var html = new StringBuilder();

            html.AppendLine(string.Format("<span class='ml-auto text-warning-m1 text-600'>{0}</span>", content));

            return html.ToString();
        }

        public static string RenderItemBoard(string content, string recordid)
        {
            var html = new StringBuilder();
            html.AppendLine(string.Format("<div class='kanban-item mb-25 radius-3px border-1 bgc-white brc-secondary-l1 px-2 pt-3 pb-3 pos-rel' data-eid='{0}'>", recordid));
            html.AppendLine(content);
            html.AppendLine("</div>");

            return html.ToString();
        }

        public static string RenderSpanDate(DateTime time, bool isCompleted = false)
        {
            var format = string.Format("<span class='badge {1}'><i class='far fa-clock mr-2px'></i> {0} </span>", time.ToString("dd/MM/yyyy HH:mm"), isCompleted ? "bgc-success-l2 text-success-d3" : "bgc-secondary-l2 text-secondary-d3");

            return format;
        }

        public static string RenderSpanProcess(int complete, int total, bool isCompleted = false)
        {
            var format = string.Format("<span class='badge {2}' style='margin-left:2px'><i class='far fa-check-square mr-2px'></i> {0} / {1} </span>", complete, total, isCompleted ? "bgc-success-l2 text-success-d3" : "bgc-secondary-l2 text-secondary-d3");

            return format;
        }
    }
}
