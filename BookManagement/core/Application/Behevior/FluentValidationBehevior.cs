using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SendGrid;

namespace Application.Behevior
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public FluentValidationBehevior()
        {

        }
        private readonly IEnumerable<IValidator<TRequest>> validator;
        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
{
            // Tạo một đối tượng ValidationContext từ request
            var context = new ValidationContext<TRequest>(request);

            // Sử dụng các validator để kiểm tra context, tập hợp các lỗi lại
            var failtures = validator
                .Select(v => v.Validate(context)) // Gọi phương thức Validate trên từng validator
                .SelectMany(result => result.Errors) // Lấy tất cả các lỗi từ kết quả Validate
                .GroupBy(x => x.ErrorMessage) // Nhóm các lỗi theo thông điệp lỗi
                .Select(x => x.First()) // Chỉ lấy lỗi đầu tiên trong mỗi nhóm
                .Where(f => f != null) // Loại bỏ các lỗi null
                .ToList(); // Chuyển đổi kết quả thành danh sách
            // Nếu có bất kỳ lỗi nào, ném ra một ValidationException
            if (failtures.Any())
                throw new ValidationException(failtures);

            // Nếu không có lỗi, gọi phương thức next và trả về kết quả
            return next();
        }
    }
}
