import axios from "axios"

const BASE_URL = "https://localhost:7154";

export const noteService = axios.create({
    baseURL: BASE_URL
});

export const getNotes = async (pageNumber: number, pageSize: number) => {
    const response = await noteService.get(`/Notes?PageNumber=${pageNumber}&PageSize=${pageSize}`);
    return response.data;
};

export const createNote = async (text: string) => {
    const response = await noteService.post("/Notes", { text });
    return response.data;
}

export const getNoteDetails = async (id: string) => {
    const response = await noteService.get(`/Notes/${id}`);
    return response.data;
}