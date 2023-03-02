import { useState } from "react";
import { api_path } from "../../../utils/api";
import { getParsedJwt, Token, User } from "../../../utils/auth";
import { loginForm as loginForm } from "../Login";

interface useLogin {
    error: string,
    token: string,
    user?: User,
    login: (loginForm: loginForm) => void,
}

export const useLogin = (): useLogin => {
    const [error, setError] = useState('')
    const [token, setToken] = useState('')
    const [user, setUser] = useState<User>()

    const login = (loginForm: loginForm) => {
        (async () => {
            const url = `${api_path}/api/account/doctor/login`
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(loginForm)
            })
            if (response.status != 200) {
                setError('Nieprawidłowa nazwa użytkownika lub hasło!');
                return { error };
            }
            else if (!response.headers.get('Content-Type')?.includes('text/plain;')) {
                return;
            }

            const token = await response.text();
            const parsedToken = getParsedJwt<Token>(token);

            if (parsedToken === undefined) {
                setError("Couldn't parse token");
                return;
            }

            setToken(token);
            setUser({
                id: parsedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
                name: parsedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
                role: parsedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
            })

            setError('')
        })();

    };


    return { error, token, user, login }
}