import { api_path } from "../../../utils/api";

export const useAddCertificate = (file: File, id: string) => {
    return (async () => {
        const formData = new FormData()
        formData.append("image", file)
        const response = await fetch(`${api_path}/api/doctors/${id}/certificates`,
        {
            method: 'POST',
            body: formData,
        });
        const body = await response.text();
        return `${api_path}/Images/${body}`
    })();
}

export const useFetchCertificates = (id: string) => {

    return (async () => {
        const response = await fetch(`${api_path}/api/doctors/${id}/certificates`);
        let json:Array<string> = await response.json();
        json = json.map(url => `${api_path}/Images/${url}`)
        return json;
    })();
}