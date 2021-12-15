export default class UserDto {
  public id: number;
  public email: string;
  public password: string;
  public firstName: string;
  public lastName: string;
  public birthday?: Date;

  constructor(
    id?: number,
    email?: string,
    password?: string,
    firstName?: string,
    lastName?: string,
    birthday?: Date
  ) {
    this.id = id || 0;
    this.email = email || "";
    this.password = password || "";
    this.firstName = firstName || "";
    this.lastName = lastName || "";
    this.birthday = birthday;
  }
}
