using AutoMapper;
using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Entities;
using Doccure.ReviewService.Settings;
using MongoDB.Driver;

namespace Doccure.ReviewService.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IMongoCollection<Review> _reviewCollection;
        private readonly IMapper _mapper;

        public ReviewService(IDataBaseSettings _settings, IMapper mapper)
        {
            var client = new MongoClient(_settings.ConnectionString);//bağlantı addresi alındı 
            var database = client.GetDatabase(_settings.DatabaseName); //bağlantı addresi uzerınden db ismi alındı 
            _reviewCollection = database.GetCollection<Review>(_settings.ReviewCollectionName); //alınaan değerler ile collection oluşturuldu
            _mapper = mapper;//dıştakı mapper ile içerdeki eşlendi 
        }
        public async Task CreateAsync(CreateReviewDto dto)
        {
            var entity = _mapper.Map<Review>(dto);
            await _reviewCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _reviewCollection.DeleteOneAsync(x => x.ReviewId == id);
        }

        public async Task<List<ResultReviewDto>> GetAllAsync()
        {
            var values = await _reviewCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultReviewDto>>(values);
        }

        public async Task<GetByIdReviewDto> GetByIdAsync(string id)
        {
            var values = await _reviewCollection.Find(x => x.ReviewId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdReviewDto>(values);
        }
    }
}
