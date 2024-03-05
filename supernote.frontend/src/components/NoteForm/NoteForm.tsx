import { Box, Button, TextField } from "@mui/material";
import { useState } from "react";

interface NoteFormProps {
    submit: (text: string) => void;
    text?: string;
}

function NoteForm({ text = "", submit }: NoteFormProps) {
    const [noteText, setNoteText] = useState(text);

    const handleNoteSubmit = (event: any) => {
        event.preventDefault();

        const htmlNote = noteText.replace(/\n/g, '<br />');
        submit(htmlNote);
        setNoteText("");
    };


    return (
        <form onSubmit={handleNoteSubmit}>
            <TextField
                label="Enter your note text"
                multiline
                fullWidth
                rows={4}
                variant="outlined"
                value={noteText}
                onChange={(e: any) => setNoteText(e.target.value)}
                onKeyDown={(e: any) => {
                    if (e.key === 'Enter' && e.shiftKey) {
                        e.preventDefault();
                    } else if (e.key === 'Enter') {
                        handleNoteSubmit(e);
                    }
                }}
            />
            <Box mt={2}>
                <Button type="submit" variant="contained" color="primary">
                    Submit
                </Button>
            </Box>
        </form>
    );
}

export default NoteForm;