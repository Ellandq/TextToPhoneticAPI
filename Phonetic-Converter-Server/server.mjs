import express from 'express';
import bodyParser from 'body-parser';
import rewrite from './rewrite.mjs';

const app = express();
const port = 3000; 

app.use(bodyParser.json());

app.post('/convert', (req, res) => {
    const { text } = req.body;
    if (!text) {
        return res.status(400).send('Text is required');
    }

    try {
        const result = rewrite(text);
        res.json({ result });
    } catch (error) {
        res.status(500).send('Error processing text');
    }
});

app.listen(port, () => {
    console.log(`Phonetic Conversion Service running at http://localhost:${port}`);
});
