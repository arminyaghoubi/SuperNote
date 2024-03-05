import { Button, Card, CardContent, Chip, Divider, Grid, Typography } from "@mui/material";
import { format } from 'date-fns';
import DateRangeIcon from '@mui/icons-material/DateRange';

interface Note {
    id: string;
    text: string;
    lastModified: Date;
}

interface NoteItemProps {
    note: Note,
    showMoreClicked: (id: string) => void;
}

function NoteItem({ note, showMoreClicked }: NoteItemProps) {
    const dateTime = format(new Date(note.lastModified), 'yyyy MMMM dd HH:mm:ss')

    const showMoreButtonClicked = () => {
        showMoreClicked(note.id);
    }

    return (
        <Grid item md={4}>
            <Card>
                <CardContent>
                    <Typography sx={{ fontSize: 15 }} color="text.secondary" gutterBottom p={1}>
                        <Chip label={dateTime} icon={<DateRangeIcon />} variant="outlined" />
                    </Typography>
                    <Divider />
                    <Typography variant="body2" p={1} mb={1}>
                        {note.text}
                    </Typography>
                    <Typography variant="body2" pl={1}>
                        <Button onClick={showMoreButtonClicked} size="small" variant="outlined" >Show More</Button>
                    </Typography>
                </CardContent>
            </Card>
        </Grid>
    );
}

export default NoteItem;