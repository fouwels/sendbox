using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proj.Models;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace proj.Repositories
{
    public class RedisRepository
    {
		private ConnectionMultiplexer redis;

		public RedisRepository()
		{
			redis = ConnectionMultiplexer.Connect("localhost");
		}
		public Mailmodel GetMail(string key)
		{
			return JsonConvert.DeserializeObject<Models.Mailmodel>(redis.GetDatabase().StringGet(key));
        }
		public async void PutMail(string key, Mailmodel mail)
		{
			await redis.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(mail));
		}
    }
}
