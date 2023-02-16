import { createContext, useContext, useState } from "react";
import { User } from "./utils/auth";

interface Context {
    token: string,
    setToken: (token: string) => void,
    user: User | undefined,
    setUser: (user: User) => void,
}

export const BeHealthContext = createContext<Context>({
    token: "",
    setToken: () => {},
    user: undefined,
    setUser: () => {},
})