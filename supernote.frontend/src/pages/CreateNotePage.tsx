import { Alert, AlertTitle, Card, CardContent, Grid, Typography } from "@mui/material";
import NoteForm from "../components/NoteForm/NoteForm"
import { createNote } from "../services/noteService";
import { useState } from "react";
import Snackbar, { SnackbarOrigin } from '@mui/material/Snackbar';

interface State extends SnackbarOrigin {
    open: boolean;
    message: string;
}

function CreateNotePage() {
    const [state, setState] = useState<State>({
        open: false,
        vertical: 'bottom',
        horizontal: 'right',
        message: ''
    });
    const { vertical, horizontal, open, message } = state;

    const handleClose = () => {
        setState({ ...state, open: false });
    };

    const create = async (text: string) => {
        const response = await createNote(text);
        setState({ ...state, open: true, message: `Has been created with id ${response.id}` });
    }

    return (
        <Grid container justifyContent="center" alignItems="center">
            <Grid item xs={12} md={6}>
                <Card>
                    <CardContent>
                        <Typography variant="h4" align="center" gutterBottom>
                            Create a Note
                        </Typography>
                        <NoteForm submit={create} />
                    </CardContent>
                </Card>
            </Grid>
            <Snackbar
                anchorOrigin={{ vertical, horizontal }}
                open={open}
                key={message}
                autoHideDuration={5000}
                onClose={handleClose}
            >
                <Alert onClose={handleClose} severity="success">
                    <AlertTitle>Success</AlertTitle>
                    {message}
                </Alert>
            </Snackbar>
        </Grid>
    );
}

export default CreateNotePage;