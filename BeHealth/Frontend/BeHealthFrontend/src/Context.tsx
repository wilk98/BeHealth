import { createContext } from "react";
import { User } from "./utils/auth";

interface Context {
    token: string,
    setToken: (token: string) => void,
    user: User | undefined,
    setUser: (user: User) => void,
    urlRedirect: string,
    setUrlRedirect: (url: string) => void,
}

export const BeHealthContext = createContext<Context>({
    token: "",
    setToken: () => {},
    user: undefined,
    setUser: () => {},
    urlRedirect: "",
    setUrlRedirect: () => {},
})