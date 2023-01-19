import { mande, MandeInstance } from "mande";

const userApi: MandeInstance = mande("http://localhost:8080/api/user");

export async function login(credentials: UserLogin): Promise<User | null> {
  return await userApi.post("login",
    credentials,
    {
      responseAs: "json"
    });
}

export async function userInfo(): Promise<User | null> {
  try {
    const user: User = await userApi.get("me", {
      responseAs: "json"
    });

    return user;
  } catch (e) {
  }
  return null;
}

export async function logout(): Promise<void> {
  await userApi.post("logout");
}