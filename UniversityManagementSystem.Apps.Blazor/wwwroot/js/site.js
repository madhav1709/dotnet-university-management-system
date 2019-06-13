let _userManager;

window.user = async (component) => {
  const user = await _userManager.getUser();

  component.invokeMethod('OnUser', JSON.stringify(user));
};

window.login = () => {
  localStorage.setItem('redirectUrl', window.location.href);

  _userManager.signinRedirect();
};

window.logout = () => {
  localStorage.setItem('redirectUrl', window.location.href);

  _userManager.signoutRedirect();
};

window.onload = () => {
  const config = {
    authority: 'https://localhost:5000',
    client_id: 'blazor',
    redirect_uri: 'https://localhost:5002/callback.html',
    response_type: 'code',
    scope: 'openid profile api',
    post_logout_redirect_uri: 'https://localhost:5002'
  };

  Oidc.Log.logger = console;

  _userManager = new Oidc.UserManager(config);
};
