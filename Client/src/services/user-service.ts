import UserDto from "@/models/user-dto";
import UserRegistration from "@/models/user-registration";
import axios, { AxiosResponse } from "axios";
import Vue from "vue";

const headers = {
  "Content-Type": "application/json",
};

const API_USERS = "https://localhost:5001/api/";

export default class UserService {
  private static _instance = axios.create({
    baseURL: API_USERS,
    headers,
  });

  public static async register(
    user: UserRegistration
  ): Promise<UserDto | undefined> {
    try {
      const response = await this._instance.post("/users", user);
      return response.data;
    } catch (error: any) {
      if (error?.response) {
        throw new Error(error?.response?.data);
      } else {
        throw new Error(error);
      }
    }
  }

  public static async login(
    email: string,
    password: string
  ): Promise<UserDto | undefined> {
    try {
      const response = await this._instance.post("/users/login", {
        email,
        password,
      });
      return response.data;
    } catch (error: any) {
      if (error?.response) {
        throw new Error(error?.response?.data);
      } else {
        throw new Error(error);
      }
    }
  }
}
