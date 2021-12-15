import UserDto from "@/models/user-dto";
import UserRegistration from "@/models/user-registration";
import { Axios } from "axios";
import Vue from "vue";

const headers = {
  "Content-Type": "application/json",
};

const API_USERS = "https://localhost:5001/api/users";

export default class UserService {
  private static _instance = new Axios({
    headers,
  });
  public static register(user: UserRegistration): Promise<UserDto> {
    // const response = await fetch(API_USERS, {
    //   method: "POST",
    //   headers,
    //   body: JSON.stringify(user),
    // });

    // if (!response.ok) {
    //   throw new Error(response.statusText);
    // }

    // return await response.json();

    return this._instance.post(API_USERS, user);
  }

  public static login(email: string, password: string): Promise<UserDto> {
    // const response = await fetch(`${API_USERS}/login`, {
    //   method: "POST",
    //   headers,
    //   body: JSON.stringify({ email, password }),
    // });

    // if (!response.ok) {
    //   throw new Error(response.statusText);
    // }

    // return await response.json();

    return this._instance.post(`${API_USERS}/login`, { email, password });
  }
}
