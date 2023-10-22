using System.Runtime.Serialization.Json;

namespace MyFitness.BL.Controller {
	public class SerializeDataSaver : IDataSaver {
		public List<T> Load<T>() where T : class {
			var formatter = new DataContractJsonSerializer(typeof(T[]));
			var fileName = typeof(T).Name;

			using(var file = new FileStream(fileName, FileMode.OpenOrCreate)) {
				if(file.Length > 0 && formatter.ReadObject(file) is T[] items) {
					return items.ToList();
				} else {
					return new List<T>();
				}
			}
		}


		public void Save<T>(List<T> item) where T : class {
			var formatter = new DataContractJsonSerializer(typeof(T[]));
			var fileName = typeof(T).Name;

			using(var file = new FileStream(fileName, FileMode.OpenOrCreate)) {
				formatter.WriteObject(file, item.ToArray());
			}
		}
	}
}
