using System.Collections.Generic;

namespace PushDeer
{
    public class BaseResult
    {
        public int code { get; set; }
        public int error { get; set; }
    }

    public class RemoveResult : BaseResult
    {
        public RemoveContent content { get; set; }
    }
    public class RemoveContent
    {
        public string message { get; set; }
    }
    public class MessagesResult : BaseResult
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public MessagesItemContent content;
    }
    public class MessagesItemContent
    {
        public List<MessagesItem> messages { get; set; }
    }
    public class MessagesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// C#测试
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pushkey_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created_at { get; set; }
    }
}
