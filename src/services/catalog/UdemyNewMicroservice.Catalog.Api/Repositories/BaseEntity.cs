using MongoDB.Bson.Serialization.Attributes;

namespace UdemyNewMicroservice.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        //snow flake . İndexlemeyi hızlandırmak için kullanılır. Üreteceği guid ler eşsiz olur.İndexleme kısmında hız kazandırır
        //Guid kullanırken bu küptühaneyi kullanmak her zaman daha avantajdır, çünkü indexleme için hız kazandırır.Birbirine yakın guidler üretir.Bu yüzden indexleme de işe yarıyor .
        [BsonElement("_id")]
        public Guid Id { get; set; }
    }
}