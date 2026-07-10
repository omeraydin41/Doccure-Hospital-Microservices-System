using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;
using Doccure.BranchService.Settings;
using MongoDB.Driver;

namespace Doccure.BranchService.Services
{
    public class BranchService : IBranchService //interface implemente edilirken zorunlu  methodların kalıtım almak zorundadır 
    {
        private readonly IMongoCollection<Branch> _brancCollection;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IDatabaseSettings settings) // DI'yı buraya uygulamış olduk
        {
            var client = new MongoClient(settings.ConnectionString); // settings ile beraber db'nin bağlantı adresini alıyoruz
            var database = client.GetDatabase(settings.DatabaseName); // db ismini alıyoruz

            // DÜZELTİLEN YER: Değeri yerel bir 'var collection' değişkenine değil, 
            // yukarıda tanımlı olan sınıfın '_brancCollection' global alanına atıyoruz.
            _brancCollection = database.GetCollection<Branch>(settings.BranchCollectionName);

            _mapper = mapper;
        } // Bunların değerleri appsettings.json'dadır ve buraya da program.cs içinden ulaşılır.

        public async Task CreateAsync(CreateBranchDto dto)
        {//ekleme işleminde önce map sonra ekleme yapılır.

            var value=_mapper.Map<Branch>(dto);//dto dan gelen değerleri branch entitysine map ediyoruz
            await _brancCollection.InsertOneAsync(value);//map edilen değerleri mongodb ye ekliyoruz
        }

        public async Task DeleteAsync(string id)
        {
            await _brancCollection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task<List<ResultBranchDto>> GetAllAsync()//listeleme için önce liste gelmeli
        {//önce listele sonra mapla 
            var valaue = await _brancCollection.Find(x => true).ToListAsync();//tüm değerleri getirir
            return _mapper.Map<List<ResultBranchDto>>(valaue);//mapleme işlemi yapıyoruz
        }

        public Task<GetBranchByIdDto> GetByIdAsync(string id)
        {//önce getir sonra maple
            var value = _brancCollection.FindAsync(x => x.BranchId == id);
            return _mapper.Map<Task<GetBranchByIdDto>>(value);
        }

        public async Task UpdateAsync(UpdateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _brancCollection.FindOneAndReplaceAsync(x => x.BranchId == dto.BranchId, value);
        }
    }
}
