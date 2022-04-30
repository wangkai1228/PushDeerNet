using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PushDeerNet
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
    public class PushDeer
    {
        private readonly HttpClient httpClient;
        public PushDeer(Uri baseAddress)
        {
            httpClient = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }
        public PushDeer(string baseAddress)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
        /// <summary>
        /// 通过苹果 idToken 登入
        /// </summary>
        /// <param name="code">Sign in with Apple 中得到的 idToken</param>
        public async Task<string> IDTokenLogin(string idToken)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/login/idtoken");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(idToken), "idToken" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 通过微信 oauth code 登入
        /// </summary>
        /// <param name="code">客户端微信授权得到的code</param>
        public async Task<string> WecodeLogin(string code)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/login/wecode");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(code), "code" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 合并用户并将旧用户删除
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="type">字符串，必须为 apple 或者 wechat</param>
        /// <param name="tokenorcode">type 为 apple时此字段为 idToken，否则为 微信code	</param>
        public async Task<string> MergeUser(string token, string type, string tokenorcode)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 获得当前用户的基本信息
        /// </summary>
        /// <param name="token">认证token</param>
        public async Task<string> GetUserInfo(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/user/info");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 注册设备
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="name">设备名称</param>
        /// <param name="deviceToken">device token（推送用）</param>
        /// <param name="isClip">是否轻应用	0为APP</param>
        public async Task<string> RegisterDevice(string token, string name, string deviceToken, int isClip)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <param name="token">认证token</param>
        public async Task<string> GetDeviceList(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 重命名设备
        /// </summary>
        /// <param name="token">认证token	
        /// <param name="deviceID">设备ID</param>
        /// <param name="newName">设备新名称</param>
        public async Task<string> RenameDevice(string token, int deviceID, string newName)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 移除设备
        /// </summary>
        /// <param name="token">认证token	
        /// <param name="deviceID">设备ID</param>
        /// <param name="newName">设备新名称</param>
        public async Task<string> RemoveDevice(string token, int deviceID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/device/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(deviceID.ToString()), "id" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 生成一个新Key
        /// </summary>
        /// <param name="token">认证token</param>
        public async Task<string> GenerateKey(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/gen");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 重命名Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        /// <param name="newKeyName">Key新名称</param>
        public async Task<string> RenameKey(string token, int keyID, string newKeyName)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 重置一个Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        public async Task<string> RegenKey(string token, int keyID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/regen");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(keyID.ToString()), "id" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 获取当前用户的Key列表
        /// </summary>
        /// <param name="token">认证token</param>
        public async Task<string> GetKeyList(string token)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/list");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 删除Key
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="keyID">Key ID</param>
        public async Task<string> RemoveKey(string token, int keyID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/key/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(keyID.ToString()), "id" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="pushkey">PushKey</param>
        /// <param name="text">推送消息内容</param>
        /// <param name="desp">消息内容第二部分，选填</param>
        /// <param name="type">格式，选填</param>
        public async Task<string> PushMessage(string pushkey, string text, string desp = "", PushType type = PushType.Text)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
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
        public async Task<string> GetMessageList(string token, int limit = 10)
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
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="token">认证token</param>
        /// <param name="messageID">消息ID</param>
        public async Task<string> RemoveMessage(string token, int messageID)
        {
            if (httpClient != null)
            {
                Uri newUri = new Uri(httpClient.BaseAddress, "/message/remove");
                MultipartFormDataContent multipartFormData = new MultipartFormDataContent()
                {
                    { new StringContent(token), "token" },
                    { new StringContent(messageID.ToString()), "id" }
                };
                return await SendRequest(newUri, multipartFormData);
            }
            return null;
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
