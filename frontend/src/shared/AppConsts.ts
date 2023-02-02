export class AppConsts{
  static LOCALSTORAGE_AUTH = "strg_data"

  static clienteBaseUrl: string;
  static backendBaseUrl: string;

  // Notificar el cierre de sesión a todas las ventanas
  static readonly BROADCAST_CHANNEL_LOGOUT = "channel-logout";
  static readonly APP_MESSAGE_LOGOUT = "logout";

  static readonly DEFAULT_ADMIN_CREDENTIAL_EMAIL = "admin@fake.com";
  static readonly DEFAULT_ADMIN_CREDENTIAL_PASSWORD = "admin";

  static readonly DEFAULT_CUSTOMER_CREDENTIAL_EMAIL = "customer@fake.com";
  static readonly DEFAULT_CUSTOMER_CREDENTIAL_PASSWORD = "customer";
}
