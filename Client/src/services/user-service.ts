import UserDto from "@/models/user-dto";
import UserRegistration from "@/models/user-registration";

const headers = {
  "Content-Type": "application/json",
};

const API_USERS = "/api/users";

export default class UserService {
  public static async register(user: UserRegistration): Promise<UserDto> {
    const response = await fetch(API_USERS, {
      method: "POST",
      headers,
      body: JSON.stringify(user),
    });

    if (!response.ok) {
      throw new Error(response.statusText);
    }

    return await response.json();
  }

  public static async login(email: string, password: string): Promise<UserDto> {
    const response = await fetch(`${API_USERS}/login`, {
      method: "POST",
      headers,
      body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
      throw new Error(response.statusText);
    }

    return await response.json();
  }
}
