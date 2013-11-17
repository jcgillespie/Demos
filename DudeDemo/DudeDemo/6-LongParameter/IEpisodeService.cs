using System;
using System.Collections.Generic;

namespace DudeDemo.Bloater
{
    [Flags]
    public enum ContentType
    {
        PhotosVideos = 1,
        ScreenshotsScreencasts = 2,
        IllustrationsArtAnimationCGI = 4,
    }

    public enum DateSearchType
    {
        DateTaken,
        DatePosted
    }

    [Flags]
    public enum LicenseSearch
    {
        NoPreference = 0,
        OnlySearchCreativeCommons = 1,
        CreativeCommonsCommercial = 2,
        CreativeCommonsDerivatives = 4
    }

    [Flags]
    public enum MediaType
    {
        Photos = 1,
        Videos = 2
    }

    public enum SafeSearchLevel
    {
        On,
        Moderate,
        Off,
    }

    public enum SearchLocation
    {
        Everyone,
        MyPhotostream,
        MyFavorites,
        FromMyContacts,
        FromMyFriendsAndFamily,
        TheGettyImagesCollection,
        TheCommons,
        UsGovernmentWorks
    }

    public enum SearchType
    {
        All,
        Any,
        ExactPhrase
    }

    public interface IFlickrSearch
    {
        IEnumerable<SearchResult> AdvancedSearch(
            string searchQuery,
            string excludeQuery,
            SearchType searchType,
            SearchLocation location,
            SafeSearchLevel safeSearchLevel,
            ContentType contentType,
            MediaType mediaType,
            Nullable<DateSearchType> dateSearchType,
            Nullable<DateTime> afterDate,
            Nullable<DateTime> beforeDate,
            LicenseSearch license,
            int pageNumber,
            int pageSize);

        IEnumerable<SearchResult> Search(
            string searchQuery,
            SearchLocation location,
            int pageNumber,
            int pageSize);
    }

    public class SearchResult { }
}