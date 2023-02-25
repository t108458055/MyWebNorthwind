namespace MyWebNorthwind.ViewModels
{
    //給使用者訊息物件
    public class Message
    {
        //自動屬性
        /// <summary>
        /// 訊息狀態
        /// </summary>
        public int status { set; get; }
        /// <summary>
        /// 訊息內容
        /// </summary>
        public string userMessage { set; get; }
        /// <summary>
        /// 時間戳
        /// </summary>
        public DateTime dateTimeNow { set; get; }
    }
}
