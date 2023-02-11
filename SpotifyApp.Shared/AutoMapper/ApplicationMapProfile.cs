using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using SpotifyApp.Api.Contracts.Base.Models;
using SpotifyApp.Api.Contracts.Tracks.Responses;
using SpotifyApp.Api.Contracts.Users.Enums;
using SpotifyApp.Api.Contracts.Users.Models;
using SpotifyApp.Api.Contracts.Users.Responses;
using SpotifyApp.Shared.Enums;
using SpotifyApp.Shared.Models;

namespace SpotifyApp.Shared.AutoMapper;

public sealed class ApplicationMapProfile : Profile
{
    public ApplicationMapProfile()
    {
        CreateMap<ItemsTypeApi, ItemType>()
            .ConvertUsingEnumMapping(opt => opt
                .MapValue(ItemsTypeApi.Artist, ItemType.Artist)
                .MapValue(ItemsTypeApi.Track, ItemType.Track)
                .MapValue(ItemsTypeApi.User, ItemType.User)
                .MapValue(ItemsTypeApi.Album, ItemType.Album)
            )
            .ReverseMap();
        
        CreateMap<ImageModelApi, Image>()
            .ValidateMemberList(MemberList.Destination);

        CreateMap<GetCurrentUserProfileResponse, UserModel>()
            .ValidateMemberList(MemberList.Destination);
        
        CreateMap<ItemModelApi, ItemModel>()
            .ValidateMemberList(MemberList.Destination);

        CreateMap<GetTrackResponse, TrackModel>()
            .ForMember(d => d.Images, opt => opt.MapFrom(s => s.Album.Images))
            .ForMember(d => d.ArtistName,
                opt => opt.MapFrom(s => string.Join(", ", s.Album.Artists.Select(a => a.Name))))
            .ForMember(d => d.AlbumName, opt => opt.MapFrom(s => string.Join(", ", s.Album.Name)))
            .ForMember(d => d.DurationMs, opt => opt.MapFrom(s => TimeSpan.FromMilliseconds(s.DurationMs)))
            .ForMember(d => d.Index, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);


    }
}