import { Grid } from '@mui/material';
import NoteItem from './NoteItem';

interface Note {
    id: string;
    text: string;
    lastModified: Date;
}

interface NoteListProps {
    totalCount: number;
    notes: Note[];
    showMoreClicked: (id: string) => void;
}


function NoteList({ notes, showMoreClicked }: NoteListProps) {
    return (
        <Grid container justifyContent="left" alignItems="center" spacing={2} mb={2}>
            {notes.map((note) => (
                <NoteItem showMoreClicked={showMoreClicked} key={note.id} note={note} />
            ))}
        </Grid>
    );
}

export default NoteList;