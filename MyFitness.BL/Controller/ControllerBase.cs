using System.Runtime.Serialization.Json;

namespace MyFitness.BL.Controller {
	public abstract class ControllerBase {
		protected void Save<T>(string fileName, T item) {
			var formatter = new DataContractJsonSerializer(typeof(T));

			using(var file = new FileStream(fileName, FileMode.OpenOrCreate)) {
				formatter.WriteObject(file, item);
			}
		}

		//T should not be a list, only array
		protected T? Load<T>(string fileName) {
			var formatter = new DataContractJsonSerializer(typeof(T));

			using(var file = new FileStream(fileName, FileMode.OpenOrCreate)) {
				if(file.Length > 0 && formatter.ReadObject(file) is T items) {
					return items;
				} else {
					return default(T);
				}

			}
		}
	}
}
