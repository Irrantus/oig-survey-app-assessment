using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Common.Models;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace QuestionnaireApi.Services
{
    public class UserService: IUserService
    {
        private Auth0Settings _auth0Settings;
        private AuthenticationApiClient _authenticationApiClient;
        private ClientCredentialsTokenRequest _clientCredentialsTokenRequest;
        private ManagementApiClient _managementApiClient;
        private IQuestionnaireService _questionnaireService;
        public UserService(
            IOptions<Auth0Settings> auth0settings,
            HttpClient httpClient,
            IQuestionnaireService questionnaireService)
        {
            _auth0Settings = auth0settings.Value;

            _authenticationApiClient = new AuthenticationApiClient(_auth0Settings.Domain);
            _clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _auth0Settings.ClientId,
                ClientSecret = _auth0Settings.ClientSecret,
                Audience = $"https://{_auth0Settings.Domain}/api/v2/"
            };

            _questionnaireService = questionnaireService;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var usersList = new List<UserViewModel>();
            var accessToken = await GetAcessTokenAsync()
                .ConfigureAwait(false);

            _managementApiClient = new ManagementApiClient(accessToken, _auth0Settings.Domain);

            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest()).ConfigureAwait(false);

            foreach(var u in users)
            {
                var user = new UserViewModel { Email = u.Email, UserId = u.UserId };

                user.QuestionnairesCount = _questionnaireService.GetQuestionnairesCountByOwnerId(u.UserId);

                usersList.Add(user);
            }

            return usersList;
        }

        private async Task<string> GetAcessTokenAsync()
        {
            var response = await _authenticationApiClient.GetTokenAsync(_clientCredentialsTokenRequest)
                .ConfigureAwait(false);

            if (string.IsNullOrEmpty(response.AccessToken))
            {
                throw new Exception("Did not get token");
            };

            return response.AccessToken;
        }
    }
}
