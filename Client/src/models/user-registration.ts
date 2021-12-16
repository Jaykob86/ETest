export default class UserRegistration {
  public email: string;
  public password: string;
  public firstName: string;
  public lastName: string;
  public birthday?: Date;

  constructor(
    email?: string,
    password?: string,
    firstName?: string,
    lastName?: string,
    birthday?: Date
  ) {
    this.email = email || "";
    this.password = password || "";
    this.firstName = firstName || "";
    this.lastName = lastName || "";
    this.birthday = birthday;
  }
}
