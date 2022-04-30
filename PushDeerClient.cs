using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace PushDeer
{
    /// <summary>
    /// 推送类型
    /// </summary>
    public enum PushType
    {
        Markdown,
        Text,
        Image
    }
    class PushDeerClient
    {
        HttpClient httpClient;
        public PushDeerClient(Uri baseUri)
        {
            httpClient = new HttpClient
            {
                BaseAddress = baseUri
            };
        }
        /// <summary>
        /// 通过苹果 idToken 登入
        /// </summary>
        /// <param name="code">Sign in with Apple 中得到的 idToken</param>
        public async void IDTokenLogin(string idToken)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/login/idtoken");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(idToken), "idToken" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 通过微信 oauth code 登入
        /// </summary>
        /// <param name="code">客户端微信授权得到的code</param>
        public async void WecodeLogin(string code)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/login/wecode");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(code), "code" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 合并用户并将旧用户删除
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="type">字符串，必须为 apple 或者 wechat</param>
        /// <param name="tokenorcode">type 为 apple时此字段为 idToken，否则为 微信code	</param>
        public async void MergeUser(string token, string type, string tokenorcode)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/user/merge");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(type), "type" },
                    { new StringContent(tokenorcode), "tokenorcode" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 获得当前用户的基本信息
        /// </summary>
        /// <param name="token">认证token</param>
        public async void GetUserInfo(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/user/info");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 注册设备
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="name">设备名称</param>
        /// <param name="deviceToken">device token（推送用）</param>
        /// <param name="isClip">是否轻应用	0为APP</param>
        public async void RegisterDevice(string token, string name, string deviceToken, int isClip)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/reg");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(name), "name" },
                    { new StringContent(deviceToken), "device_id" },
                    { new StringContent(isClip.ToString()), "is_Clip" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <param name="token">认证token</param>
        public async void GetDeviceList(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 重命名设备
        /// </summary>
        /// <param name="token">认证token	
        /// <param name="deviceID">设备ID</param>
        /// <param name="newName">设备新名称</param>
        public async void RenameDevice(string token, int deviceID, string newName)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/rename");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(deviceID.ToString()), "id" },
                    { new StringContent(newName), "name" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 移除设备
        /// </summary>
        /// <param name="token">认证token	
        /// <param name="deviceID">设备ID</param>
        /// <param name="newName">设备新名称</param>
        public async void RemoveDevice(string token, int deviceID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(deviceID.ToString()), "id" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 生成一个新Key
        /// </summary>
        /// <param name="token">认证token</param>
        public async void GenerateKey(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/gen");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 重命名Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        /// <param name="newKeyName">Key新名称</param>
        public async void RenameKey(string token, int keyID, string newKeyName)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/rename");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(keyID.ToString()), "id" },
                    { new StringContent(newKeyName), "name" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 重置一个Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        public async void RegenKey(string token, int keyID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/regen");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(keyID.ToString()), "id" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 获取当前用户的Key列表
        /// </summary>
        /// <param name="token">认证token</param>
        public async void GetKeyList(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 删除Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        public async void RemoveKey(string token, int keyID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(keyID.ToString()), "id" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="pushkey">PushKey</param>
        /// <param name="text">推送消息内容</param>
        /// <param name="desp">消息内容第二部分，选填</param>
        /// <param name="type">格式，选填</param>
        public async void PushMessage(string pushkey, string text, string desp = "", PushType type = PushType.Text)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/message/push");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(pushkey), "pushkey" },
                    { new StringContent(text), "text" },
                    { new StringContent(desp), "desp" },
                    { new StringContent(type.ToString()), "type" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 获得当前用户的消息列表
        /// </summary>
        /// <param name="token">认证token</param>
        public async Task<string> GetMessageList(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/message/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token,Encoding.UTF8), "token" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 获得当前用户的消息列表
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="limit">消息条数	默认为10，最大100</param>
        public async void GetMessageList(string token, int limit = 10)
        {
            if (limit > 100)
            {
                limit = 100;
            }
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/message/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(limit.ToString()), "limit" }
                };
                await SendRequest(newUri, multipartFormData);
            }
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="messageID">消息ID</param>
        public async void RemoveMessage(string token, int messageID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/message/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(messageID.ToString()), "id" }
                };
                string result = await SendRequest(newUri, multipartFormData);
                RemoveResult removeResult = JsonConvert.DeserializeObject<RemoveResult>(result);
                if (removeResult != null && removeResult.code == 0)
                {
                    Console.WriteLine($"移除||MessageID = {messageID}||Message = {removeResult.content.message}||成功");
                }
            }
        }
        /// <summary>
        /// 清空所有的消息
        /// </summary>
        /// <param name="token">认证token</param>
        public async void ClearAllMessage(string token)
        {
            string result = await GetMessageList(token);
            Console.WriteLine($"{result}");
            MessagesResult messages = JsonConvert.DeserializeObject<MessagesResult>(result);
            if (messages.code == 0)
            {
                Console.WriteLine("获取成功！！！");
                if (messages.content.messages.Count > 0)
                {
                    for (int i = 0; i < messages.content.messages.Count; i++)
                    {
                        RemoveMessage(token, messages.content.messages[i].id);
                    }
                }
            }
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="newUri">请求Uri</param>
        /// <param name="multipartFormData">POST数据</param>
        private async Task<string> SendRequest(Uri newUri, MultipartFormDataContent multipartFormData)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsync(newUri, multipartFormData);
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
