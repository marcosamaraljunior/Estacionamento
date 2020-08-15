using Newtonsoft.Json;

namespace Dominio.DTOs
{
    public struct CarroDTO
    {
        [JsonProperty("modelo")]
        public string Modelo { get; set; }

        [JsonProperty("cor")]
        public string Cor { get; set; }

        [JsonProperty("placa")]
        public string Placa { get; set; }

        [JsonProperty("tamanho")]
        public string Tamanho { get; set; }
    }
}