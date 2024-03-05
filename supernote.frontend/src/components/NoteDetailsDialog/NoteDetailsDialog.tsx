import { Button, Chip, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import DateRangeIcon from '@mui/icons-material/DateRange';
import { format } from 'date-fns';

interface Note {
    id: string;
    text: string;
    lastModified: Date;
}

interface NoteDetailsDialogProps {
    note?: Note;
    close: () => void;
}

function NoteDetailsDialog({ note = undefined, close }: NoteDetailsDialogProps) {

    const handleClose = () => {
        close();
    };

    const dateTime = format(new Date(note?.lastModified??"1998-01-01"), 'yyyy MMMM dd HH:mm:ss')

    return (
        <Dialog
            open={Boolean(note)}
            onClose={handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
        >
            <DialogTitle id="alert-dialog-title">
                <Chip label={dateTime} icon={<DateRangeIcon />} variant="outlined" />
            </DialogTitle>
            <DialogContent>
                <DialogContentText id="alert-dialog-description">
                    <p>
                        {note?.text}
                    </p>
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={handleClose}>Close</Button>
            </DialogActions>
        </Dialog>
    );
}

export default NoteDetailsDialog;